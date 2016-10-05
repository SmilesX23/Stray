using UnityEngine;
using System.Collections;

public class AIMoveTestScript : MonoBehaviour {

	int rand;
	bool needStop = false;








	void Start () 
	{
		
	}
	


	void Update () 
	{
		if(needStop == false)
		{
			MoveForwards ();	
		}

	}





	void MoveForwards()
	{
		transform.Translate (Vector3.forward * Time.deltaTime); 
	}










	#region TriggerFunctions
	void OnTriggerEnter(Collider otherGO)
	{
		needStop = true;

		rand = Random.Range (0, 2);
		Debug.Log ("The random int is equal to: " + rand);


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
		needStop = false;
	}
	#endregion 

}
