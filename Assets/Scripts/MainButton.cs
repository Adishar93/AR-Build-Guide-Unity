using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject intelsense;
	public GameObject home;
	public GameObject goto1;
	public GameObject speed;
	public GameObject dropdown;
    public int count =1;
    void Start()
    {
    	goto1 = GameObject.FindGameObjectWithTag("goto");
  		goto1.SetActive(false);
  		home = GameObject.FindGameObjectWithTag("home");
  		home.SetActive(false);
  		intelsense = GameObject.FindGameObjectWithTag("is");
  		intelsense.SetActive(false);
  		//speed = GameObject.FindGameObjectWithTag("as");
  		speed.SetActive(false);
  		// dropdown = GameObject.FindGameObjectWithTag("Controller");
  		 //dropdown.SetActive(false);   
  		count = 1;
    }

	public void setFalse()
    {
    	//button1= gameObject.GetComponent<Button>();
    	//button1.gameObject.SetActive(false);
    	count = count + 1;
    	Debug.Log(count);
    	
    	int value = count%2;

    	switch(value) 
   		{
		     case 0: 
		     {
			    Debug.Log("In if");
		    	home.SetActive(true);
		    	goto1.SetActive(true);
		    	intelsense.SetActive(true);
		    	speed.SetActive(true); 
          //dropdown.SetActive(false); 
		    	break;  		
		    }
     		case 1: 
		     {
		     	Debug.Log("In else");
		    	home.SetActive(false);
		    	goto1.SetActive(false);
		    	intelsense.SetActive(false); 
		    	speed.SetActive(false);
		    	dropdown.SetActive(false);
		    	break;
		   	 }
    	}
    	// Debug.Log("SetActive as true111111111");
    	// home.SetActive(true);
    	// goto1.SetActive(true);
    	// intelsense.SetActive(true);
    	//GameObject.FindGameObjectWithTag("Goto").SetActive(true);
		//GameObject.FindGameObjectWithTag("IntelligentSense").SetActive(true);
    	Debug.Log("SetActive as false");
    }
}
