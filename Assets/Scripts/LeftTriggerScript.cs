using UnityEngine;
using System.Collections;

public class LeftTriggerScript : MonoBehaviour {

	public GameObject mothership;
	AIMoveScript mothershipMS;

	// Use this for initialization
	void Start () 
	{
		mothershipMS = mothership.GetComponent<AIMoveScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}







	void OnTriggerEnter()
	{

	}


	void OnTriggerStay()
	{
		
	}


	void OnTriggerExit()
	{

	}

}
