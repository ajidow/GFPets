using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAndDeleteModel
{
   public static void CreateModelFromFile()
    {
        if (Init.MainConfig.isOpen[Init.MainConfig.slot])
        {
            Debug.Log("opened");
        }
        else
        {
            Model_Config tmpConfig = Init.MainConfig;
            string atlasTextReadIn = System.IO.File.ReadAllText(tmpConfig.config[tmpConfig.slot].AtlasFilePath);
            TextAsset atlasText = new TextAsset(atlasTextReadIn);

            string jsonTextReadIn = System.IO.File.ReadAllText(tmpConfig.config[tmpConfig.slot].JsonFilePath);
            TextAsset skeletonJson = new TextAsset(jsonTextReadIn);

            Texture2D texturesReadIn = new Texture2D(2, 2);
            byte[] picData = System.IO.File.ReadAllBytes(tmpConfig.config[tmpConfig.slot].Texture2DPath);
            texturesReadIn.LoadImage(picData);
            Texture2D[] textures = new Texture2D[1];
            textures[0] = texturesReadIn;
            textures[0].name = tmpConfig.config[tmpConfig.slot].TextureName;

            Material materialPropertySource = new Material(Shader.Find("Spine/Skeleton"));

            Init.MainConfig.Models[Init.MainConfig.slot] = new DataAssetsFromExports(atlasText, skeletonJson, textures, materialPropertySource);


            Init.MainConfig.Models[Init.MainConfig.slot].CreateRuntimeAssetsAndGameObject();
            Init.MainConfig.isOpen[Init.MainConfig.slot] = true;
            Init.MainConfig.Models[Init.MainConfig.slot].runtimeSkeletonDataAsset.GetSkeletonData(false);
            Init.MainConfig.Models[Init.MainConfig.slot].runtimeSkeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(Init.MainConfig.Models[Init.MainConfig.slot].runtimeSkeletonDataAsset);
            Init.MainConfig.Models[Init.MainConfig.slot].runtimeSkeletonAnimation.AnimationState.SetAnimation(0, Init.MainConfig.config[Init.MainConfig.slot].initialStatus, true);
        }
    }
    public static void DeleteModel()
    {
        GameObject GameObjectDestory = GameObject.Find("New Spine GameObject");
        if (Init.MainConfig.isOpen[Init.MainConfig.slot])
        {
            Object.Destroy(GameObjectDestory);
            Init.MainConfig.isOpen[Init.MainConfig.slot] = false;
        }
        else
            Debug.Log("nothing");
    }
}
