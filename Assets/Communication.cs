using UnityEngine;
using System.Collections;
using Photon;

[RequireComponent(typeof(AudioSource))]
public class Communication : PunBehaviour {

    #region member variables

    public AudioClip[] m_sounds;
    public GameObject[] m_signals;

    private AudioSource m_source;
    private bool m_canCommunicate = true;

    #endregion

    void Start ()
    {
        m_source = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
        if (m_canCommunicate)
        {
            if (Input.GetButtonDown("YesBtn"))
            {
                //sending this as a RPC will trigger it's execution on every client...
                photonView.RPC("Signal", PhotonTargets.All, 0, photonView.viewID);
            }

            if (Input.GetButtonDown("NoBtn"))
            {
                photonView.RPC("Signal", PhotonTargets.All, 1, photonView.viewID);
            }

            if (Input.GetButtonDown("AskBtn"))
            {
                photonView.RPC("Signal", PhotonTargets.All, 2, photonView.viewID);
            }

            if (Input.GetButtonDown("FollowBtn"))
            {
                photonView.RPC("Signal", PhotonTargets.All, 3, photonView.viewID);
            }
        }
    }

    [PunRPC]
    void Signal(int index, int viewID)
    {
        if (photonView.viewID == viewID)
        {
            StartCoroutine(Communicate(index));
        }
    }

    IEnumerator Communicate(int index)
    {
        m_canCommunicate = false;
        m_source.PlayOneShot(m_sounds[index]);
        m_signals[index].SetActive(true);
        yield return new WaitForSeconds(m_sounds[index].length);
        m_signals[index].SetActive(false);
        m_canCommunicate = true;
    }
}
