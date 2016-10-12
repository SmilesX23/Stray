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
	    if (other.tag == "Player")
        {
            other.GetComponent<Player>().AddLight(m_lightRegeneration * Time.deltaTime);
        }

        if (other.tag == "AI")
        {
            other.GetComponent<NavmeshAI>().SwitchGoals();
        }
    }
}
