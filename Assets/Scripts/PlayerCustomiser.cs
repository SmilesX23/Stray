using UnityEngine;
using Photon;
using System.Collections;

public class PlayerCustomiser : Photon.PunBehaviour {

    public GameObject m_PlayerBody;
    public GameObject m_1stPersPlayerBody;

	void Start ()
    {
	    if (photonView.isMine)
        {
            
            m_1stPersPlayerBody.gameObject.SetActive(true);
        }
        if (!photonView.isMine)
        {
            m_PlayerBody.gameObject.SetActive(true);
            
        }
    }
	
	void Update () {
	
	}
}
