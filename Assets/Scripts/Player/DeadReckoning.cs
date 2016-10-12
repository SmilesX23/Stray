using UnityEngine;
using System.Collections;

public class DeadReckoning : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    float lastSyncTime = 0f;
    float syncDelay = 0f;
    float syncTime = 0f;
    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;





    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = transform.position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            syncTime = 0f;
            syncDelay = Time.time - lastSyncTime;
            lastSyncTime = Time.time;
            startPosition = transform.position;
            endPosition = syncPosition;
        }
    }

































}
