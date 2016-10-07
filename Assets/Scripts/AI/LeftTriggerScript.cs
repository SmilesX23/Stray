using UnityEngine;
using System.Collections;

public class LeftTriggerScript : MonoBehaviour {

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
        mothershipMS.leftTriggered = true;
    }





	void OnTriggerExit()
	{
        mothershipMS.stopMoving = false;
        mothershipMS.leftTriggered = false;
    }

}
