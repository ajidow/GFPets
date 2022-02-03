using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModeLoop : MonoBehaviour
{
	private GameObject[] models;
	private Model_Config MainConfig;
	private float tapTimer;
	private const float tapThreshold = 0.1f;
	private enum status
	{
		None = 0,
		Lsingle,
		LlongDown,
		Rsingle
	}

	public ShowModeLoop(ref Model_Config MainConfig)
	{
		this.models = new GameObject[10];
		this.MainConfig = MainConfig;
		tapTimer = 0.0f;
	}

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
		Debug.Log(Screen.width);
		Debug.Log(Screen.height);
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

	private int checkHit()
	{
		status status;
		status = status.None;
		if(Input.GetMouseButtonUp(1))//右键抬起
        {
			status = status.Rsingle;
        }
		if (Input.GetMouseButton(0))//按下，判断是长按or other status;
		{
		   if(tapTimer == 0.0f)
			{
				tapTimer = Time.time;
			}
		   if(Time.time>tapTimer + tapThreshold)//长按
			{
				status = status.LlongDown;
			}
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(Time.time > tapTimer+tapThreshold)
            {
				status = status.None;
            }else if(Time.time <= tapThreshold+tapTimer)
            {
				status = status.Lsingle;
            }
			tapTimer = 0.0f;
		}
		return (int)status;
	}
	private void RsingleClicked()
    {
		GameObject res = new GameObject();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			res = hit.collider.gameObject;
		}
		if(res != null)
        {
			GameObject rootModel = res.transform.parent.parent.gameObject;
			//////////////////////*********	Developing area			**********//////////////////
			rootModel.GetComponent<Spine.Unity.SkeletonAnimation>().AnimationState.SetAnimation(0, "move", true);
        }
	}
	public void ClickFeedBack()
    {
		switch(checkHit())
        {
			case (int)status.Lsingle:break;
			case (int)status.LlongDown:break;
			case (int)status.Rsingle:RsingleClicked();break;
			default:break;
        }
		 
	}
}
