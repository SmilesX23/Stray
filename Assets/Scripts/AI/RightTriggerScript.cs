using UnityEngine;
using System.Collections;

public class RightTriggerScript : MonoBehaviour {


	AIMoveScript mothershipMS;

	// Use this for initialization
	void Start () 
	{
       
		mothershipMS = transform.parent.GetComponent<AIMoveScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void OnTriggerEnter()
	{
        mothershipMS.stopMoving = true;
        mothershipMS.rightTriggered = true;
    }





	void OnTriggerExit()
	{
        mothershipMS.stopMoving = false;
        mothershipMS.rightTriggered = false; ;
    }

}
