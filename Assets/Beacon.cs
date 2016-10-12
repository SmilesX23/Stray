using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

	void Start () {
	
	}
	
	void OnTriggerEnter (Collider other)
    {
	    if (other.tag == "AI")
        {
            other.GetComponent<NavmeshAI>().SwitchGoals();
        }
	}
}
