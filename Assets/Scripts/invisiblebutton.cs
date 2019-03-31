using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class invisiblebutton : MonoBehaviour
{
    // Start is called before the first frame update
    

   public GameObject intelsense;
	public GameObject home;
	public GameObject goto1;
	public GameObject speed;
	public Dropdown dropdown;
    Animation anim;
	//public GameObject dropdown1;
    public int count =0;
    public void closeall()
    {
    	//goto1 = GameObject.FindGameObjectWithTag("goto");
  		goto1.SetActive(false);
  		//home = GameObject.FindGameObjectWithTag("home");
  		home.SetActive(false);
  		//intelsense = GameObject.FindGameObjectWithTag("is");
  		intelsense.SetActive(false);
  		//speed = GameObject.FindGameObjectWithTag("as");
  		speed.SetActive(false);
        

        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.persistentDataPath, "AssetBundles/armodel"));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        string[] arr = myLoadedAssetBundle.GetAllAssetNames();


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




            //anim.AddClip(all[dropdown.value], count + "step");
            //var clips = myLoadedAssetBundle.LoadAsset<AnimationClip>("shelfanim55.fbx");
            NextStep.count = dropdown.value;
                anim.Play(dropdown.value + "step");
                GameObject stepText = GameObject.Find("Step");
                Text nn = stepText.GetComponent<Text>();
                nn.text = "Step " + (NextStep.count + 1);
                Debug.Log(all.Length);


                

           

            myLoadedAssetBundle.Unload(false);
            myLoadedAssetBundle = null;

            
        }

    }

    // dropdown = GameObject.FindGameObjectWithTag("Controller");
    // dropdown.SetActive(false);
    // dropdown1 = GameObject.FindGameObjectWithTag("Controller1");
    // dropdown1.SetActive(false);
     
    }

