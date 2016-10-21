﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]

public class DeadReckoning : Photon.MonoBehaviour, IPunObservable 
{
	

	private Vector3 latestCorrectPos;
	private Vector3 onUpdatePos;
	private float fraction;


	public void Start()
	{
		this.latestCorrectPos = transform.position;
		this.onUpdatePos = transform.position;
	}

    public void Update()
    {
        if (this.photonView.isMine)
        {
            return;     // if this object is under our control, we don't need to apply received position-updates 
        }

        // We get 10 updates per sec. Sometimes a few less or one or two more, depending on variation of lag.
        // Due to that we want to reach the correct position in a little over 100ms. We get a new update then.
        // This way, we can usually avoid a stop of our interpolated cube movement.
        //
        // Lerp() gets a fraction value between 0 and 1. This is how far we went from A to B.
        //
        // So in 100 ms, we want to move from our previous position to the latest known. 
        // Our fraction variable should reach 1 in 100ms, so we should multiply deltaTime by 10.


        this.fraction = fraction + Time.deltaTime * 10;
        transform.localPosition = Vector3.Lerp(this.onUpdatePos, this.latestCorrectPos, this.fraction); // set our pos between A and B
    }



    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 pos = transform.localPosition;
			Quaternion rot = transform.localRotation;
			stream.Serialize(ref pos);
			stream.Serialize(ref rot);
		}
		else
		{
			// Receive latest state information
			Vector3 pos = Vector3.zero;
			Quaternion rot = Quaternion.identity;

			stream.Serialize(ref pos);
			stream.Serialize(ref rot);

			this.latestCorrectPos = pos;                // save this to move towards it in FixedUpdate()
			this.onUpdatePos = transform.localPosition; // we interpolate from here to latestCorrectPos
			this.fraction = 0;                          // reset the fraction we alreay moved. see Update()

			transform.localRotation = rot;              // this sample doesn't smooth rotation
		}
	}


	


























}
