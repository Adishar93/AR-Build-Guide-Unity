using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnHome : MonoBehaviour
{
    public void backToHome()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
                Application.Quit();
           
        }
    }
}
