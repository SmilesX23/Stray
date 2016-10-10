using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour {


	public Text interactText;// This is the "Press E to interact" text object

	// Use this for initialization
	void Start () 
	{
		interactText = GameObject.Find ("InteractText").GetComponent<Text> ();//When the player is instantiated, search for the InteractText object, then acquire its text.
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit; //This is used to see what teh Ray has hit.

		if (Physics.Raycast (transform.position, transform.forward,out hit, 3)) //Checks the ray that was cast from the FPC, 3 units ahead, repeatedly.
		{
			if(hit.collider.gameObject.tag == "AI")//If ray hit collider with AI tag
			{
				interactText.enabled = true; 
				if(Input.GetKeyDown(KeyCode.E))
				{
					//What happens if you interact with the AI agent.
				}
			}

			if(hit.collider.gameObject.tag == "Player")
			{
				interactText.enabled = true;
				if(Input.GetKeyDown(KeyCode.E))
				{
					//What happens if you interact with the other player.
				}

			}
		} 
		else //In all other cases, I.E: if nothing is happening, make sure the text prompt isn't showing.
		{
			interactText.enabled = false;
		}
	}
}