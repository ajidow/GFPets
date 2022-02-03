using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreateAndDeleteModel
{
   public static void CreateModelFromFile(ref Model_Config MainConfig,int WhichModel)
    {
        if (MainConfig.isOpen[WhichModel])
        {
            Debug.Log("opened");
        }else if(MainConfig.isEmpty[WhichModel])
        {
            Debug.Log("Empty Slot");
        }
        else
        {

            string atlasTextReadIn = System.IO.File.ReadAllText(MainConfig.config[WhichModel].AtlasFilePath);
            TextAsset atlasText = new TextAsset(atlasTextReadIn);

            string jsonTextReadIn = System.IO.File.ReadAllText(MainConfig.config[WhichModel].JsonFilePath);
            TextAsset skeletonJson = new TextAsset(jsonTextReadIn);

            Texture2D texturesReadIn = new Texture2D(2, 2);
            byte[] picData = System.IO.File.ReadAllBytes(MainConfig.config[WhichModel].Texture2DPath);
            texturesReadIn.LoadImage(picData);
            Texture2D[] textures = new Texture2D[1];
            textures[0] = texturesReadIn;
            textures[0].name = MainConfig.config[WhichModel].TextureName;

            Material materialPropertySource = new Material(Shader.Find("Spine/Skeleton"));

            MainConfig.Models[WhichModel] = new DataAssetsFromExports(atlasText, skeletonJson, textures, materialPropertySource);
            

            MainConfig.Models[WhichModel].CreateRuntimeAssetsAndGameObject();
            MainConfig.isOpen[WhichModel] = true;

            MainConfig.Models[WhichModel].runtimeSkeletonDataAsset.GetSkeletonData(false);

            string GameObjectToAttach = "Model" + WhichModel.ToString();//要把新建的skeletonAnimation挂载上去的gameobject
            GameObject neo =new GameObject(GameObjectToAttach);
            MainConfig.Models[WhichModel].runtimeSkeletonAnimation = SkeletonAnimation.AddToGameObject(neo, MainConfig.Models[WhichModel].runtimeSkeletonDataAsset);
            MainConfig.Models[WhichModel].runtimeSkeletonAnimation.AnimationState.SetAnimation(0, MainConfig.config[WhichModel].initialStatus, true);
           // SceneManager.MoveGameObjectToScene(neo, SceneManager.GetSceneByName("ShowMode"));
        }
    }
    public static void DeleteModel(ref Model_Config MainConfig,int WhichModel)
    {
            if (MainConfig.isOpen[WhichModel])
            {
                string NameOfGameObjectToDestory = "Model" + WhichModel.ToString();
                GameObject GameObjectToDestory = GameObject.Find(NameOfGameObjectToDestory);
                
                Object.Destroy(GameObjectToDestory);
                Init.MainConfig.isOpen[WhichModel] = false;
            }
            else
                Debug.Log("nothing");
    }
}
