using UnityEngine;
using System.Collections;

public class AIMoveTestScript : MonoBehaviour {

	int rand;
	bool stopMoving = false;


	void Start () 
	{
		
	}


	void Update () 
	{
		if(stopMoving == false)
		{
			MoveForwards ();	
		}

	}




	//This will become Wander() once fully implemented.
	void MoveForwards()
	{
		transform.Translate (Vector3.forward * Time.deltaTime); 
	}










	#region TriggerFunctions
	void OnTriggerEnter(Collider otherGO)
	{
		stopMoving = true;
		rand = Random.Range (0, 2);
	}


	void OnTriggerStay(Collider otherGO)
	{
		if(rand == 0)
		{
			transform.Rotate (Vector3.up * Time.deltaTime * 10f); 
		}

		if(rand == 1)
		{
			transform.Rotate (Vector3.down * Time.deltaTime * 10f);
		}
	}


	void OnTriggerExit(Collider otherGO)
	{
		stopMoving = false;
	}
	#endregion 

}
