using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSpeed()
    {
        GameObject Model = GameObject.Find("armodel(Clone)");
        Animation anim = Model.GetComponent<Animation>();
        foreach (AnimationState item in anim)
        {
            item.speed = 0.5f;
        }

    }
}
