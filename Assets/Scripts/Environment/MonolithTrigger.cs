using UnityEngine;
using Photon;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonolithTrigger : Photon.PunBehaviour {
    #region Variables
    private PersistentData m_pData;
    private float m_timeToEnd;

    public int m_totalNumberOfBeacons;
    public int m_numberOfLitBeacons;

    public int m_totalPlayerCount;
    public int m_playersInTrigger;

    public Text monolithText;
    public Text remainingTimeText;

    public bool countdown = false;

    #endregion




    #region GenericFunctions

    // Use this for initialization
    void Start()
    {
        m_pData = (PersistentData)FindObjectOfType(typeof(PersistentData));
        m_timeToEnd = m_pData.m_timeToEndLevel;

        m_numberOfLitBeacons = 0;
        m_totalPlayerCount = 0;

        m_totalNumberOfBeacons = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown)
        {
            m_timeToEnd -= Time.deltaTime;
            remainingTimeText.text = m_timeToEnd.ToString();

            if (m_timeToEnd < 0f)
            {
                SceneManager.LoadScene("Intro Scene");
            }
        }
    }

   
    #endregion




    #region BeaconFunctions
    public void BeaconLit()//Incrememnt the number of lit beacons
    {
        Debug.Log("BeaconLit() called");
        m_numberOfLitBeacons++;
        if (AllBeaconsLit())
        {
            //notify all clients that the monolith is lit
            photonView.RPC("Activate", PhotonTargets.All);
        }
    }

    [PunRPC]
    void Activate()
    {
        Debug.Log("All the beacons are lit!!");
        foreach (Transform go in GetComponentsInChildren<Transform>(true))
        {
            go.gameObject.SetActive(true);
        }
        GetComponent<BoxCollider>().enabled = true;
    }

    bool AllBeaconsLit() //Check to see if all the beacons have bit lit by the players.
    {
        Debug.Log("AllBeaconsLitCalled check has been called");
        return (m_numberOfLitBeacons == m_totalNumberOfBeacons);
    }
    #endregion

    



    #region TriggerFunctions

    void OnTriggerEnter(Collider collider)//If a player enters the trigger, up th eplayer counts in trigger by 1
    {
        if(collider.gameObject.tag == "Player" && AllBeaconsLit())
        {
            print("ending");
            EndGame();
        }
        
    }

    

    

     void EndGame()
    {
        monolithText.gameObject.SetActive(true);
        remainingTimeText.gameObject.SetActive(true);
        remainingTimeText.text = m_timeToEnd.ToString();
        countdown = true;
    }

    #endregion
}
