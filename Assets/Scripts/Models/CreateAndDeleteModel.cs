using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDeleteModel
{
   public static void CreateModelFromFile(ref Model_Config MainConfig)
    {
        if (MainConfig.isOpen[MainConfig.slot])
        {
            Debug.Log("opened");
        }
        else
        {

            string atlasTextReadIn = System.IO.File.ReadAllText(MainConfig.config[MainConfig.slot].AtlasFilePath);
            TextAsset atlasText = new TextAsset(atlasTextReadIn);

            string jsonTextReadIn = System.IO.File.ReadAllText(MainConfig.config[MainConfig.slot].JsonFilePath);
            TextAsset skeletonJson = new TextAsset(jsonTextReadIn);

            Texture2D texturesReadIn = new Texture2D(2, 2);
            byte[] picData = System.IO.File.ReadAllBytes(MainConfig.config[MainConfig.slot].Texture2DPath);
            texturesReadIn.LoadImage(picData);
            Texture2D[] textures = new Texture2D[1];
            textures[0] = texturesReadIn;
            textures[0].name = MainConfig.config[MainConfig.slot].TextureName;

            Material materialPropertySource = new Material(Shader.Find("Spine/Skeleton"));

            MainConfig.Models[MainConfig.slot] = new DataAssetsFromExports(atlasText, skeletonJson, textures, materialPropertySource);
            

            MainConfig.Models[MainConfig.slot].CreateRuntimeAssetsAndGameObject();
            MainConfig.isOpen[MainConfig.slot] = true;

            MainConfig.Models[MainConfig.slot].runtimeSkeletonDataAsset.GetSkeletonData(false);

            string GameObjectToAttach = "Model" + MainConfig.slot.ToString();//要把新建的skeletonAnimation挂载上去的gameobject
            GameObject neo =new GameObject(GameObjectToAttach);
            
            MainConfig.Models[MainConfig.slot].runtimeSkeletonAnimation = SkeletonAnimation.AddToGameObject(neo, MainConfig.Models[MainConfig.slot].runtimeSkeletonDataAsset);
            MainConfig.Models[MainConfig.slot].runtimeSkeletonAnimation.AnimationState.SetAnimation(0, MainConfig.config[MainConfig.slot].initialStatus, true);
        }
    }
    public static void DeleteModel(ref Model_Config MainConfig)
    {
            if (MainConfig.isOpen[MainConfig.slot])
            {
                string NameOfGameObjectToDestory = "Model" + MainConfig.slot.ToString();
                GameObject GameObjectToDestory = GameObject.Find(NameOfGameObjectToDestory);
                
                Object.Destroy(GameObjectToDestory);
                Init.MainConfig.isOpen[MainConfig.slot] = false;
            }
            else
                Debug.Log("nothing");
    }
}
