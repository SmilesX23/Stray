using UnityEngine;
using System.Collections;

public class RightTriggerScript : MonoBehaviour {


	AIMoveScript mothershipMS;

	// Use this for initialization
	void Start () 
	{
       
		mothershipMS = transform.parent.GetComponent<AIMoveScript>();//Get a reference to the AIMoveScript in the parent
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void OnTriggerEnter()
	{
        mothershipMS.stopMoving = true;//Tell NPC to stop moving.
        mothershipMS.rightTriggered = true;//Tell AIMoveScript that one of the right triggers has been activated
    }





	void OnTriggerExit()
	{
        mothershipMS.stopMoving = false;//Start moving again
        mothershipMS.rightTriggered = false; //Right trigger status reset.
    }

}
