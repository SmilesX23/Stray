using UnityEngine;
using System.Collections;

public class MonolithTrigger : MonoBehaviour
{
    #region Variables
    private PersistentData m_pData;
    private float m_timeToEnd;

    public int m_totalNumberOfBeacons;
    public int m_numberOfLitBeacons;

    public int m_totalPlayerCount;
    public int m_playersInTrigger;
    #endregion




    #region GenericFunctions

    // Use this for initialization
    void Start()
    {
        m_pData = (PersistentData)FindObjectOfType(typeof(PersistentData));
        m_timeToEnd = m_pData.m_timeToEndLevel;

        m_numberOfLitBeacons = 0;
        m_totalPlayerCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EndTheGame()
    {
        Debug.Log("Game Is Over!!");
    }
    #endregion




    #region BeaconFunctions
    public void BeaconLit()//Incrememnt the number of lit beacons
    {
        m_numberOfLitBeacons++;
        if (AllBeaconsLit())
        {
            Debug.Log("All the beacons are lit!!");
            foreach (Transform go in GetComponentsInChildren<Transform>(true))
            {
                go.gameObject.SetActive(true);
            }
            GetComponent<BoxCollider>().enabled = true;
        }
    }




    bool AllBeaconsLit() //Check to see if all the beacons have bit lit by the players.
    {
        return (m_numberOfLitBeacons == m_totalNumberOfBeacons);
    }
    #endregion

    



    #region TriggerFunctions

    void OnTriggerEnter(Collider collider)//If a player enters the trigger, up th eplayer counts in trigger by 1
    {
        if(collider.gameObject.tag == "Player")
        {
            print("ending");
            StartCoroutine(EndGame());
        }
        
    }

    //void OnTriggerStay(Collider collider)//Check to se if the beacons are lit and if all the players are present in the trigger zone
    //{
    //    if(AllBeaconsLit() && m_playersInTrigger == m_totalPlayerCount )//If beacons are lit and all players are present, end the game
    //    {
    //        EndTheGame();
    //    }
    //}

    //void OnTriggerExit(Collider collider)//If a player leaves the trigger
    //{
    //    if(collider.gameObject.tag == "Player")
    //    {
    //        m_playersInTrigger--;
    //    }
        
    //}

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(m_timeToEnd);
        Application.Quit();
    }

    #endregion
}
