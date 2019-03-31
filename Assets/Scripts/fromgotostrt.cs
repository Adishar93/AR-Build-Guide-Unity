using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class fromgotostrt : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas temp_obj;
    public Canvas showing_obj;
    public Canvas invisible;
    AnimationClip[] all;
    public static int ListPopulated = 0;
    void Start()
    {
        //dropbox = GameObject.FindGameObjectWithTag("Controller");
		//dropbox.SetActive(true);
    }

    public void populateList()
	{

        invisible.gameObject.SetActive(false);
        showing_obj.gameObject.SetActive(false);
        temp_obj.gameObject.SetActive(true);

            Debug.Log("IN PopulateList");
        
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.persistentDataPath, "AssetBundles/armodel"));
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }

            all = myLoadedAssetBundle.LoadAllAssets<AnimationClip>();

            int count = 0;
            foreach (AnimationClip clip in all)
            {
                count++;
            }

            GameObject stepText = GameObject.FindGameObjectWithTag("countstep");
            Text nn = stepText.GetComponent<Text>();


            nn.text = count.ToString();
            Debug.Log(count);
            myLoadedAssetBundle.Unload(false);

        }
	}

