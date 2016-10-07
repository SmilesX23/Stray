using UnityEngine;
using System.Collections;

public class LeftTriggerScript : MonoBehaviour {

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
        mothershipMS.stopMoving = true; //Tell the AIMoveScript to stop the NPC and start rotating
        mothershipMS.leftTriggered = true;//Tell the AIMoveScript that one of the left side triggers was activated.
    }





	void OnTriggerExit()
	{
        mothershipMS.stopMoving = false;//Resume normal forward march
        mothershipMS.leftTriggered = false;//Left trigger no longer activated
    }

}
