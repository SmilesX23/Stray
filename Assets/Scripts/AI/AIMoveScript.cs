using UnityEngine;
using System.Collections;

public class AIMoveScript : MonoBehaviour 
{
    public bool stopMoving = false;
	public bool moveToPlayer = false;
	public bool fleeFromPlayer = false;

	public Vector3 playerPosition;

    public bool leftTriggered = false;
    public bool rightTriggered = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	
    
    // Update is called once per frame
	void Update () 
	{
        

		if (stopMoving == false)
        {
			//Currently the default movement is a straight line, avoiding trees and such. Will eventually be a wander function.
            MoveForwards();
        }

		if(moveToPlayer)//If the AI is moving the player.
		{
			if((transform.position - playerPosition).magnitude > 2)//If the player is closer than 2 units.
			{
				//We move towards the player.
				transform.position = Vector3.MoveTowards (transform.position, playerPosition, Time.deltaTime);
			}
			//We look towards the player.
			Quaternion lookRotation = Quaternion.LookRotation ((transform.position - playerPosition));

			transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime);

	
		}
        


		if(!moveToPlayer)
		{
			//The following 3 functions basically explain themselves.
			if (leftTriggered)
			{
				leftTriggerOn();
			}


			if (rightTriggered)
			{
				rightTriggerOn();
			}


			if (leftTriggered && rightTriggered)
			{
				bothTriggered();
			}
		}

	}










	#region UtilityFunctions
	//Steps to take once the triggers activate, either rotate left, or right.
    void leftTriggerOn()
    {
        transform.Rotate(Vector3.up);
    }

    void rightTriggerOn()
    {
        transform.Rotate(Vector3.down);
    }

    void bothTriggered()
    {
		transform.Rotate (Vector3.up);
    }
    
    
    
    //This will become Wander() once fully implemented.
	void MoveForwards()
	{
		transform.Translate (Vector3.forward * Time.deltaTime); 
	}
	#endregion
}
