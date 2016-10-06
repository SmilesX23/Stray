using UnityEngine;
using System.Collections;

public class AIMoveScript : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MoveForwards ();
	}


	//This will become Wander() once fully implemented.
	void MoveForwards()
	{
		transform.Translate (Vector3.forward * Time.deltaTime); 
	}


}
