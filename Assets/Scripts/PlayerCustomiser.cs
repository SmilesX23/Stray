using UnityEngine;
using Photon;
using System.Collections;

public class PlayerCustomiser : Photon.PunBehaviour {

	void Start ()
    {
	    if (photonView.isMine)
        {
            foreach(Transform tr in GetComponentInChildren<Transform>())
            {
                if (tr.gameObject.name == "PlayerBody")
                {
                    tr.gameObject.SetActive(false);
                }
            }
        }
	}
	
	void Update () {
	
	}
}
