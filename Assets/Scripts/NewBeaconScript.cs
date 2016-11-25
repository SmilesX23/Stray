using UnityEngine;
using System.Collections;
using Photon; 

public class NewBeaconScript : Photon.PunBehaviour {

    #region member variables

    private PersistentData m_pData;
    private float m_lightToActivate;
    private bool m_isActive = false;

    public GameObject m_monolith;
    public GameObject LitBeacon;

    #endregion

    void Start()
    {
        m_pData = (PersistentData)FindObjectOfType(typeof(PersistentData));
        m_lightToActivate = m_pData.m_lightToActivateBeacon;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            other.GetComponent<NavmeshAI>().SwitchGoals();
        }

        if (other.tag == "Player")
        {
            if (other.GetComponent<Player>() != null && other.GetComponent<Player>().m_lightPool > m_lightToActivate && !m_isActive)
            {
                other.GetComponent<Player>().m_lightPool -= m_lightToActivate;
                photonView.RPC("Activate", PhotonTargets.All);
            }
        }
    }
    [PunRPC]
    void Activate()
    {
        m_isActive = true;

        //light's up!
        foreach (Transform go in GetComponentsInChildren<Transform>(true))
        {
            go.gameObject.SetActive(true);
        }

        m_monolith.GetComponent<MonolithTrigger>().BeaconLit();
        Network.Instantiate(LitBeacon, transform.position, Quaternion.identity,0);
        Network.Destroy(this.gameObject);
      
       
    }
}
