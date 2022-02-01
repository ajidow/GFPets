using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Button_Start : MonoBehaviour
{
    private GameObject button_start;
    void Start()
    {
        button_start = GameObject.Find("Button_Start");
        button_start.GetComponent<Button>().onClick.AddListener(Button_Start_OnClick);
    }

    void Button_Start_OnClick()
    {
        string atlasTextReadIn = System.IO.File.ReadAllText("C:\\Users\\wangyj\\Desktop\\M4 SOPMOD IIMod.atlas.txt");
        TextAsset atlasText = new TextAsset(atlasTextReadIn);
        

        string jsonTextReadIn = System.IO.File.ReadAllText("C:\\Users\\wangyj\\Desktop\\RM4 SOPMOD IIMod.json");
        TextAsset skeletonJson = new TextAsset(jsonTextReadIn);
        

        Texture2D texturesReadIn = new Texture2D(2, 2);
        byte[] picData = System.IO.File.ReadAllBytes("C:\\Users\\wangyj\\Desktop\\M4 SOPMOD IIMod.png");
        texturesReadIn.LoadImage(picData);
        Texture2D[] textures = new Texture2D[1];
        textures[0] = texturesReadIn;
        textures[0].name = "M4 SOPMOD IIMod";

        Material materialPropertySource = new Material(Shader.Find("Spine/Skeleton"));

        DataAssetsFromExports exampleModel = new DataAssetsFromExports(atlasText,skeletonJson,textures,materialPropertySource);

        

        exampleModel.CreateRuntimeAssetsAndGameObject();
        exampleModel.runtimeSkeletonDataAsset.GetSkeletonData(false);
        exampleModel.runtimeSkeletonAnimation = Spine.Unity.SkeletonAnimation.NewSkeletonAnimationGameObject(exampleModel.runtimeSkeletonDataAsset);
        exampleModel.runtimeSkeletonAnimation.AnimationState.SetAnimation(0, "wait", true);
    }
}
