using UnityEngine;
using System.Collections;
using Photon;

[RequireComponent(typeof(AudioSource))]
public class CommunicationSignal : PunBehaviour {

    #region member variables

    public AudioClip m_sound;

    private AudioSource m_source;

    #endregion

    void Start ()
    {
        m_source = GetComponent<AudioSource>();
        StartCoroutine(Communicate());
	}
	
    IEnumerator Communicate()
    {
        m_source.PlayOneShot(m_sound);
        yield return new WaitForSeconds(m_sound.length);
        PhotonNetwork.Destroy(this.gameObject);
    }
}
