using UnityEngine;
using System.Collections;

public class LightFountain : MonoBehaviour {

    #region member variables

    private PersistentData m_pData;
    private float m_lightPool;
    private float m_lightRegeneration;
    private bool m_canBeDepleted;

    #endregion

    void Start ()
    {
        m_pData = (PersistentData)FindObjectOfType(typeof(PersistentData));

        m_canBeDepleted = m_pData.m_wellsDeplete;
        m_lightPool = m_pData.m_wellLightAmount;
        m_lightRegeneration = m_pData.m_wellLightRecharge;
	}
	
	void OnTriggerStay (Collider other)
    {
	    if (other.tag == "Player" && other.GetComponent<Player>() != null)
        {
            if (m_canBeDepleted)
            {
                m_lightPool -= m_lightRegeneration * Time.deltaTime;
                if (m_lightPool <= 0)
                {
                    //disable particle systems and return so that player does not receive light
                    foreach (Transform obj in GetComponentsInChildren<Transform>())
                    {
                        if (obj != this.transform)
                        {
                            obj.gameObject.SetActive(false);
                        }
                    }
                }
            }
            other.GetComponent<Player>().AddLight(m_lightRegeneration * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AI")
        {
            other.GetComponent<NavmeshAI>().SwitchGoals();
        }
    }
}
