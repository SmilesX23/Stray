using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    #region member variables


    private PersistentData m_pData;
    public float m_lightPool;
    private float m_lightConsumption;
    private bool m_canBecomeGhost;

    #endregion

    void Start ()
    {
        m_pData = (PersistentData)FindObjectOfType(typeof(PersistentData));

        m_lightPool = m_pData.m_playerLightPool;
        m_lightConsumption = m_pData.m_playerLightConsumption;
        m_canBecomeGhost = m_pData.m_playerCanGhost;


    }

    void Update ()
    {
        if (GetComponent<CharacterController>().velocity != Vector3.zero)
        {
            m_lightPool -= Time.deltaTime * m_lightConsumption;
            UpdateLight();
            if (m_lightPool <= 0)
            {
                if (!m_canBecomeGhost)
                {
                    print("dead no ghost");
                    Application.Quit();
                }
                else
                {
                    DisablePlayerStuff();
                    m_lightPool = 0;
                    print("dead");
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

    public void AddLight(float light)
    {
        if (m_lightPool < m_pData.m_playerLightPool)
        {
            m_lightPool += light;
        }
    }

    void UpdateLight()
    {
        Light light = GetComponentInChildren<Light>();
        light.intensity = m_lightPool / m_pData.m_playerLightPool;
    }
}
