using UnityEngine;
using System.Collections;
using Photon;
using UnityEngine.UI;


public class Communication : PunBehaviour {

    #region member variables

    public GameObject[] m_signals;

    public Text m_playerID;

    private bool m_canCommunicate = true;

    #endregion

    void Start ()
    {
        m_playerID = GameObject.Find("PlayerIDGO").GetComponent<Text>();
	}
	
	void Update ()
    {
        m_playerID.text = PhotonNetwork.player.ID.ToString();

        if (m_canCommunicate)
        {
            if (Input.GetButtonDown("YesBtn") && photonView.isMine)
            {
                PhotonNetwork.Instantiate(m_signals[0].name, transform.position, Quaternion.identity, 0);
            }

            if (Input.GetButtonDown("NoBtn") && photonView.isMine)
            {
                PhotonNetwork.Instantiate(m_signals[1].name, transform.position, Quaternion.identity, 0);
            }

            if (Input.GetButtonDown("AskBtn") && photonView.isMine)
            {
                PhotonNetwork.Instantiate(m_signals[2].name, transform.position, Quaternion.identity, 0);
            }

            if (Input.GetButtonDown("FollowBtn") && photonView.isMine)
            {
                PhotonNetwork.Instantiate(m_signals[3].name, transform.position, Quaternion.identity, 0);
            }
        }
    }
}
