using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]

public class DeadReckoning : Photon.MonoBehaviour
{

    private Rigidbody m_rb;

    public Vector3 correctPlayerPosition;
    public Quaternion correctPlayerRotation;
    public Vector3 currentVelocity;

    public float updateTime;



    public void Start()
	{
        m_rb = this.gameObject.GetComponent<Rigidbody>();
        PhotonNetwork.sendRate = 30;
        PhotonNetwork.sendRateOnSerialize = 30;
	}



    public void Update()
    {
       if(!photonView.isMine)
        {
            Vector3 projectedPosition = this.correctPlayerPosition +currentVelocity * (Time.time - updateTime);

            transform.position = Vector3.Lerp(transform.position, projectedPosition, Time.deltaTime * 4);
            transform.rotation = Quaternion.Lerp (transform.rotation, this.correctPlayerRotation, Time.deltaTime * 4);
        }
    }



    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       if(stream.isWriting)
        {
            //If we are outputting our stuff to the other networked players
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(m_rb.velocity);
        }
        else
        {
            correctPlayerPosition = (Vector3)stream.ReceiveNext();
            correctPlayerRotation = (Quaternion)stream.ReceiveNext();
            currentVelocity = (Vector3)stream.ReceiveNext();

            updateTime = Time.time;
        }
    }





























}
