using UnityEngine;
using System.Collections;

public class AIMoveScript : MonoBehaviour 
{
    public bool stopMoving = false;


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
            MoveForwards();
        }

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

	/*
	void MoveBackwards()
	{
		transform.Translate (Vector3.back * Time.deltaTime); 
	}
    */
    
}
