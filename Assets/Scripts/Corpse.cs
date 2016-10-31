using UnityEngine;
using Photon;
using System.Collections;

public class Corpse : Photon.PunBehaviour {

    #region member variables

    public float m_corpseLight = 10;

    private GameObject m_collider;

    #endregion

    void OnTriggerEnter(Collider other)
    {
        m_collider = other.gameObject;
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
