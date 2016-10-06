using UnityEngine;
using System.Collections;

public class RightTriggerScript : MonoBehaviour {

	public GameObject mothership;
	AIMoveScript mothershipMS;

	// Use this for initialization
	void Start () 
	{
        mothership = GameObject.Find("NPC1");
        mothershipMS = mothership.GetComponent<AIMoveScript>();
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


	void OnTriggerStay()
	{
		
	}


	void OnTriggerExit()
	{
        mothershipMS.stopMoving = false;
        mothershipMS.rightTriggered = false; ;
    }

}
