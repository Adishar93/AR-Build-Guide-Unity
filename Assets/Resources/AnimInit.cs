using UnityEngine;
using System.IO;
using UnityEngine.UI;

using UnityEditor;
using Vuforia;
public class AnimInit : ContentPositioningBehaviour, ITrackableEventHandler
{
    Animator animator;
    Animation anim;

    private TrackableBehaviour mTrackableBehaviour;
    string url;
    


    void Start()
    {
        //StartCoroutine(GetModel());
        Debug.Log("The main Path:"+Application.persistentDataPath);
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        
    }
    void Update()
    {
    
    }
    public void test()
    {
        Debug.Log("Test");
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.persistentDataPath, "AssetBundles/armodel"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        string[] arr = myLoadedAssetBundle.GetAllAssetNames();
        foreach (string item in arr)
        {
            Debug.Log("Inside assets");
            Debug.Log(item);
        }
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
            Debug.Log("Model is null");
            Model = Instantiate(myLoadedAssetBundle.LoadAsset("armodel")) as GameObject;
             AnimationClip[] all=myLoadedAssetBundle.LoadAllAssets<AnimationClip>();

            Model.AddComponent<Animation>();
            anim = Model.GetComponent<Animation>();

            int count = 0;
            foreach (AnimationClip item in all)
            {
                //debug.log("this is the clip " + item + " next " + item.length + "");
                // debug.log(item);
                //var clips = myloadedassetbundle.loadasset<animationclip>("chuckfight1.fbx");

                // anim.addclip(item, item.tostring());
                anim.AddClip(item,count + "step");
                count++;
                //debug.log("inside assets");

            }
            //var clips = myLoadedAssetBundle.LoadAsset<AnimationClip>("shelfanim55.fbx");

        }


        myLoadedAssetBundle.Unload(false);
        myLoadedAssetBundle = null;
       
        //animator = Model.GetComponent<Animator>();

        // animator = Model.GetComponent<Animator>();
        // Debug.Log("");
        // anim.AddClip(clips,"test");
        //anim.Play("test");

        // animator.runtimeAnimatorController = controller1;
        //Material newMat = Resources.Load("chuck", typeof(Material )) as Material;
        //Model.GetComponent<Renderer>().material = newMat;
        
        Model.transform.parent = mTrackableBehaviour.transform;
        Model.transform.localPosition = new Vector3(0f, 0f, 0f);
        Model.transform.localRotation = Quaternion.identity;
        Model.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        
        Model.SetActive(true);
        anim = Model.GetComponent<Animation>();
        anim.Stop();



        //Debug.Log("Did the clip Play?"+anim.Play("crazy"));

    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Test will be called");
            test();
            Debug.Log("Test must have been called");
        }
    }

   

    
    //IEnumerator GetModel()
    //{
    //    WWW www = new WWW(url);
    //    yield return www;
    //}
}
