using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makedropdown : MonoBehaviour
{
    // Start is called before the first frame update
    
   public GameObject intelsense;
	public GameObject home;
	public GameObject goto1;
	public GameObject speed;
	public GameObject dropdown;
	public GameObject dropdown1;
    public int count =0;
   public void valueclicked()
   {
   		goto1 = GameObject.FindGameObjectWithTag("goto");
  		goto1.SetActive(false);
  		home = GameObject.FindGameObjectWithTag("home");
  		home.SetActive(false);
  		intelsense = GameObject.FindGameObjectWithTag("is");
  		intelsense.SetActive(false);
  		speed = GameObject.FindGameObjectWithTag("as");
  		speed.SetActive(false);
  		// dropdown = GameObject.FindGameObjectWithTag("Controller");
  		// dropdown.SetActive(false);
  		// dropdown1 = GameObject.FindGameObjectWithTag("Controller1");
  		// dropdown1.SetActive(false);
  		count = 1;
   }
}
