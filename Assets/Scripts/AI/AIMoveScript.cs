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

		if(moveToPlayer)
		{
			//If a player enters the detection radius and we have to approach, this triggers.
			transform.position = Vector3.MoveTowards (transform.position,playerPosition,Time.deltaTime);
		}
        



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


    
}
