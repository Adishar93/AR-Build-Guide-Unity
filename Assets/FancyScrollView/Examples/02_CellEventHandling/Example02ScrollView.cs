using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace FancyScrollView
{
    public class Example02ScrollView : FancyScrollView<Example02CellDto, Example02ScrollViewContext>
    {
    	    public Canvas temp_obj;
        Animation anim;
        public Canvas showing_obj;
    public Canvas invisible;
        AnimationClip[] all;


        [SerializeField]
        ScrollPositionController scrollPositionController;

        void Awake()
        {
            scrollPositionController.OnUpdatePosition(p => UpdatePosition(p));
            SetContext(new Example02ScrollViewContext { OnPressedCell = OnPressedCell });
        }

        public void UpdateData(List<Example02CellDto> data)
        {
            cellData = data;
            scrollPositionController.SetDataCount(cellData.Count);
            UpdateContents();
        }

        void OnPressedCell(Example02ScrollViewCell cell)
        {
            //hhh
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.persistentDataPath, "AssetBundles/armodel"));
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }

            all = myLoadedAssetBundle.LoadAllAssets<AnimationClip>();

            GameObject Model = GameObject.Find("armodel(Clone)");

            anim = Model.GetComponent<Animation>();
            if (anim == null)
            {
                Debug.Log("anim is null");
                Model.AddComponent<Animation>();
                anim = Model.GetComponent<Animation>();
            }

            myLoadedAssetBundle.Unload(false);


            invisible.gameObject.SetActive(true);
        showing_obj.gameObject.SetActive(true);
        temp_obj.gameObject.SetActive(false);            
            scrollPositionController.ScrollTo(cell.DataIndex, 0.4f);
            Context.SelectedIndex = cell.DataIndex;
            if (anim == null)
            {
                Debug.Log("anim is null");
                Model.AddComponent<Animation>();
                anim = Model.GetComponent<Animation>();
            }

                anim.Play(Context.SelectedIndex + "step");
                GameObject stepText = GameObject.Find("Step");
                Text nn = stepText.GetComponent<Text>();
                nn.text = "Step " + (Context.SelectedIndex + 1);
                Debug.Log(all.Length);


                Debug.Log("Animation " + Context.SelectedIndex + " " + all[Context.SelectedIndex]);

    


            UpdateContents();


        }
    }
}
