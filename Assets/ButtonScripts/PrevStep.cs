using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class PrevStep : MonoBehaviour
{
    Animator animator;
    Animation anim;
    

    public void goToPrevStep()
    {   
       

        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.persistentDataPath, "AssetBundles/armodel"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        string[] arr = myLoadedAssetBundle.GetAllAssetNames();

        //string path1 = "Assets/Resources/Chuckcontroller.controller";
        //myLoadedAssetBundle.LoadAsset("chuckfight1", typeof(Motion[]));
        //AssetDatabase.LoadAssetAtPath("Assets/Resources/ChuckFight1.fbx", typeof(Motion[]));
        //var clips = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/Resources/ChuckFight1.fbx");

        //var controller1 = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPathWithClip(path1, clips);
        //Debug.Log(clips[0]);

        //GameObject GroundPlaneStage = GameObject.Find("Ground Plane Stage");
        //GameObject[] all = GroundPlaneStage.GetComponents<GameObject>();
        //foreach( GameObject go in all)
        //{
        //    Debug.Log(go);
        //}

        GameObject Model = GameObject.Find("armodel(Clone)");
        if (Model == null)
        {
            Debug.Log("Sorry, Next Step Failed to Load");
            return;
        }
        else
        {
            Debug.Log("Model is null");
            AnimationClip[] all = myLoadedAssetBundle.LoadAllAssets<AnimationClip>();

            anim = Model.GetComponent<Animation>();
            if (anim == null)
            {
                Debug.Log("anim is null");
                Model.AddComponent<Animation>();
                anim = Model.GetComponent<Animation>();
            }

            if (NextStep.count > 0)
            { 
                NextStep.count = NextStep.count - 1;
            
            //anim.AddClip(all[NextStep.count], NextStep.count + "step");
            //var clips = myLoadedAssetBundle.LoadAsset<AnimationClip>("shelfanim55.fbx");
            
            
            anim.Play(NextStep.count + "step");
                
                GameObject stepText = GameObject.Find("Step");
                Text nn = stepText.GetComponent<Text>();
                nn.text = "Step " + (NextStep.count + 1);
                Debug.Log(all.Length);
            

            Debug.Log("Animation " + NextStep.count + " " + all[NextStep.count]);

                }

            myLoadedAssetBundle.Unload(false);
            myLoadedAssetBundle = null;

            animator = Model.GetComponent<Animator>();
        }

    }
}

