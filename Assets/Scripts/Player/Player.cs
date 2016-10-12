using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    #region member variables


    private PersistentData m_pData;
    private float m_lightPool;
    private float m_lightConsumption;
    private bool m_canBecomeGhost;

    #endregion

    void Start ()
    {
        m_pData = (PersistentData)FindObjectOfType(typeof(PersistentData));

        m_lightPool = m_pData.m_playerLightPool;
        m_lightPool = m_pData.m_playerLightCOnsumption;
        m_canBecomeGhost = m_pData.m_playerCanGhost;


    }

    void Update ()
    {
        if (GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            m_lightPool -= Time.deltaTime * m_lightConsumption;
            if (m_lightPool <= 0)
            {
                if (!m_canBecomeGhost)
                {
                    Application.Quit();
                }
                else
                {
                    DisablePlayerStuff();
                }
            }
        }
    }

    void DisablePlayerStuff()
    {
        foreach (Light li in GetComponentsInChildren<Light>())
        {
            li.enabled = false;
        }
        foreach (MeshRenderer mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.enabled = false;
        }
        foreach (InteractScript Is in GetComponentsInChildren<InteractScript>())
        {
            Is.enabled = false;
        }
    }
}
