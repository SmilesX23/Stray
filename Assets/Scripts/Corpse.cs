using UnityEngine;
using Photon;
using System.Collections;

public class Corpse : Photon.PunBehaviour {

    #region member variables

    public float m_corpseLight = 10;

    #endregion

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().AddLight(m_corpseLight);
        
        photonView.RPC("DepleteCorpse", PhotonTargets.All);
    }

    [PunRPC]
    void DepleteCorpse()
    {
        m_corpseLight = 0;
        foreach (Transform obj in GetComponentsInChildren<Transform>())
        {
            if (obj != this.transform)
            {
                obj.gameObject.SetActive(false);
            }
        }
    }

}
