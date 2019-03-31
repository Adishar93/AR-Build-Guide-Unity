using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;


namespace FancyScrollView
{
    public class Example02Scene : MonoBehaviour
    {
        [SerializeField]
        Example02ScrollView scrollView;
        void Start()
        {

            GameObject stepText = GameObject.Find("NoStep");
                Text nn = stepText.GetComponent<Text>();
                // Debug.Log(nn.text);
                Debug.Log("Haan");

            var cellData = Enumerable.Range(1, Int32.Parse(nn.text))
                .Select(i => new Example02CellDto { Message = "Step: " + i })
                .ToList();

            scrollView.UpdateData(cellData);
        }
    }
}
