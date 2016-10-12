using UnityEngine;
using System.Collections;

public class PlayerDetectionScript : MonoBehaviour {

	int rand;
	bool towards = false;
	
	Vector3 distance;
	AIMoveScript mothershipMS;

	// Use this for initialization
	void Start () 
	{
		mothershipMS = transform.parent.GetComponent<AIMoveScript> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}


	void OnTriggerEnter(Collider collider)
	{
		//If the trigger collided with a player, decide whether or not to approach or flee.
		if(collider.gameObject.tag == "Player")
		{
				Debug.Log ("Towards set to true!");
				towards = true;
		}

	}

	void OnTriggerStay(Collider collider)
	{
		if(collider.gameObject.tag == "Player")
		{

			//If decided to approach, set variables in AIMoveScript to allow approach
			if(towards)
			{
				mothershipMS.stopMoving = true;
				mothershipMS.fleeFromPlayer = false;
				mothershipMS.moveToPlayer = true;
				mothershipMS.playerPosition = collider.gameObject.transform.position;
			}
			

			//Get vector between current position and player position
			distance = transform.position - collider.transform.position;

			//If distance is less than 3, stop the AI agent from moving. 
			//This stops the AI from running into the player, or if the plyer catches up, stops the NPC so they can talk.
			if(distance.magnitude < 3)
			{
				mothershipMS.stopMoving = true;
			}	
		}

	}


	void OnTriggerExit(Collider collider)
	{
		//When the player leaves the radius, reset all the variables and proceed with normal behaviour
		if(collider.gameObject.tag == "Player")
		{
			towards = false;//Reset Enter variables
			mothershipMS.stopMoving = false; //Allow agent to start moving again (part of normal behaviour)
			mothershipMS.moveToPlayer = false; //AI agent is no longer moving towards the player.
			mothershipMS.fleeFromPlayer = false; //AI agent is no longer fleeing from player.
			mothershipMS.playerPosition = new Vector3(0.0f,0.0f,0.0f);//Set the players position to (0,0,0). This effectively resets the vector.
		}

	}




}
