using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModeLoop : MonoBehaviour
{
	private GameObject[] models;
	private GameObject draggingModel;
	private bool isDraggingModel;
	private Model_Config MainConfig;
	private float tapTimer;
	private const float tapThreshold = 0.1f;
	private enum Clickstatus
	{
		None = 0,
		Lsingle,
		LlongDown,
		LlongUp,
		Rsingle
	}

	public ShowModeLoop(ref Model_Config MainConfig)
	{
		this.models = new GameObject[10];
		draggingModel = new GameObject();
		this.MainConfig = MainConfig;
		tapTimer = 0.0f;
		isDraggingModel = false;
	}

	//init
	public void loopInit()
	{
		CameraInit();
		ModelsInit();
		BindHitBox();
	}
	private void ModelsInit()
	{
		for (int i = 1; i < 10; ++i)
		{
			if (Init.MainConfig.isEmpty[i] == false)
			{
				CreateAndDeleteModel.CreateModelFromFile(ref MainConfig, i);
				string NewGameObject = "Model" + i.ToString();
				GameObject neo = GameObject.Find(NewGameObject);
				int x = MainConfig.config[i].screenX;
				int y = MainConfig.config[i].screenY;
				float scale = MainConfig.config[i].scale;
				//float posX = ((x - 250) /9) * i-x/2;//一字排开 posX = (-screenX/2)+(screenX-picwidth/2)/items*itemNumber

				//neo.transform.position = new Vector3(posX,0,0);
				neo.transform.localScale = new Vector3(scale, scale, 0f);
			}
		}
	}
	private void CameraInit()
	{
		
		Camera cam = GameObject.Find("Main Camera").GetComponent<Camera>();
		cam.orthographicSize = Screen.height / 2;
/*		Debug.Log(Screen.width);
		Debug.Log(Screen.height);*/
	}
	private void BindHitBox()
	{
		for (int i = 1; i <= 9; ++i)
		{
			if (MainConfig.isEmpty[i] == false)
			{
				string name = "Model" + i.ToString();
				models[i] = GameObject.Find(name);

				CreateBoneFollowerAndCollider("face", "Face Collider", models[i]);
				CreateBoneFollowerAndCollider("body", "Body Collider", models[i]);
				
			}
		}
	}
	private void CreateBoneFollowerAndCollider(string BoneFollowerName,string ColliderName,GameObject rootModel)
	{
		GameObject boneFollower = new GameObject(BoneFollowerName);
		boneFollower.transform.SetParent(rootModel.transform);

		boneFollower.AddComponent<Spine.Unity.BoneFollower>();
		boneFollower.GetComponent<Spine.Unity.BoneFollower>().skeletonRenderer=rootModel.GetComponent<Spine.Unity.SkeletonAnimation>();
		boneFollower.GetComponent<Spine.Unity.BoneFollower>().boneName = BoneFollowerName;

		GameObject Collider = new GameObject(ColliderName);
		Collider.transform.SetParent(boneFollower.transform);
		Collider.AddComponent<BoxCollider>();
	}

	//click
	public void ClickFeedBack()
    {
		switch(checkClickStatus())
        {
			case (int)Clickstatus.Lsingle:LsingleClicked(); break;
			case (int)Clickstatus.LlongDown:LlongDownClicked(); break;
			case (int)Clickstatus.LlongUp:LlongUpClicked();break;
			case (int)Clickstatus.Rsingle:RsingleClicked();break;
			default:break;
        }
		 
	}
	private int checkClickStatus()
	{
		Clickstatus Clickstatus;
		Clickstatus = Clickstatus.None;
		if(Input.GetMouseButtonUp(1))//右键抬起
        {
			Clickstatus = Clickstatus.Rsingle;
        }
		if (Input.GetMouseButton(0))//按下，判断是长按or other status;
		{
		   if(tapTimer == 0.0f)
			{
				tapTimer = Time.time;
			}
		   if(Time.time>tapTimer + tapThreshold)//长按
			{
				Clickstatus = Clickstatus.LlongDown;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(Time.time > tapTimer+tapThreshold)
            {
				Clickstatus = Clickstatus.LlongUp;//取消长按
            }else if(Time.time <= tapThreshold+tapTimer)
            {
				Clickstatus = Clickstatus.Lsingle;
            }
			tapTimer = 0.0f;
		}
		return (int)Clickstatus;
	}
	private void RsingleClicked()
    {
		GameObject hitObject = CheckHitObject();
		if(hitObject != null)
        {
			GameObject rootModel = hitObject.transform.parent.parent.gameObject;//被点击的collider的根节点，也就是model

			int modelNumber = rootModel.name[5] - '0';//eg: if name == Model9, modelNumber == 9
			MainConfig.ModelClickMotionNumber[modelNumber] += 1;
			Debug.Log(MainConfig.config[modelNumber].ClickAnimationName.Length);
			if (MainConfig.ModelClickMotionNumber[modelNumber] >= MainConfig.config[modelNumber].ClickAnimationName.Length)//
				MainConfig.ModelClickMotionNumber[modelNumber] = 0;

			var trackEntry = rootModel.GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState.SetAnimation(0, MainConfig.config[modelNumber].ClickAnimationName[MainConfig.ModelClickMotionNumber[modelNumber]], true);
			trackEntry.MixDuration = MainConfig.config[modelNumber].TransitionTime;//smooth transition
        }
	}
	private void LsingleClicked()
    {
		//羽音（待添加）
    }
	private void LlongDownClicked()
    {
		GameObject hitObject = CheckHitObject();
		if (isDraggingModel == false)
		{
			if (hitObject != null)
			{

				
					isDraggingModel = true;
					GameObject rootModel = hitObject.transform.parent.parent.gameObject;
					draggingModel = rootModel;

					int modelNumber = rootModel.name[5] - '0';
					MainConfig.ModelClickMotionNumber[modelNumber] = 0;//下次单击从第一个动作开始循环
					var trackEntry = rootModel.GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState.SetAnimation(0, MainConfig.config[modelNumber].DragAnimationName, true);
					trackEntry.MixDuration = MainConfig.config[modelNumber].TransitionTime;
				

			}
		}
		else
		{
			if (draggingModel != null)
			{
				var mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
				draggingModel.transform.position = Camera.main.ScreenToWorldPoint(mousepos);
			}
		}
	}
	private void LlongUpClicked()
    {
		int modelNumber = draggingModel.name[5] - '0';
		var trackEntry = draggingModel.GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState.SetAnimation(0, MainConfig.config[modelNumber].ClickAnimationName[0], true);
		trackEntry.MixDuration = MainConfig.config[modelNumber].TransitionTime;
		isDraggingModel = false;
		draggingModel = null;
	}
	private GameObject CheckHitObject()
    {
		GameObject res = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			res = hit.collider.gameObject;
		}
		return res;
	}
	
}
