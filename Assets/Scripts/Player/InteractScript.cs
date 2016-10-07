using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour {


	public Text interactText;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward,out hit, 3)) 
		{
			if(hit.collider.gameObject.tag == "AI")
			{
				interactText.enabled = true;
			}
		} 
		else 
		{
			interactText.enabled = false;
		}
	}
}