using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class NetworkManager : MonoBehaviour {

	const string VERSION = "v0.0.1";

	public string roomName = "Stray";
    public int m_maxPlayersPerRoom = 5;
    

	public GameObject playerPrefabName;
	public Camera camera;
	public Transform spawnPoint;
    //public Transform spawnPoint1;

    private GameObject m_persistentData;

    //Persistent data transferral variables (Used to get the users room name)
  

    void Awake()
    {
        if (!GameObject.Find("PersistentDataGO"))
        {
            m_persistentData = new GameObject("PersistentDataGO");
            m_persistentData.AddComponent<PersistentData>();
        }
        else
        {
            GameObject.Find("PersistentDataGO");
        }
    }


	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings (VERSION);//Connect to the lobby using the given settings
	}
	





	void OnJoinedLobby()
	{
		Debug.Log ("Lobby joined");

 
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = (byte)m_maxPlayersPerRoom };//Create custom room options, here the room isn't visible to others and has 10 ppl max.


		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);//Join or create the room if it doesn't already exist.
	}






	void OnJoinedRoom()
	{
		//When you join the room, you create a clone of the Player prefab, and enable the Character Controller, FirstPersonController, Camera and Audio Listener.
		//This is done to keep each individual clone independent if being run on the same machine (Excellent for playtesting and debugging)
		Debug.Log ("Room joined");

		GameObject myPlayer = PhotonNetwork.Instantiate (playerPrefabName.name, spawnPoint.position, spawnPoint.rotation, 0);

        //GameObject NPC = PhotonNetwork.Instantiate(NPCname.name, spawnPoint1.position, spawnPoint1.rotation, 0);

		//The following components are disabled by default, to insure clone independence on a single machine.
		myPlayer.GetComponent <CharacterController> ().enabled = true;//Turn on the character controller
		myPlayer.GetComponent <FirstPersonController> ().enabled = true;//Turn on the FirstPersonController script.
		myPlayer.GetComponentInChildren<Camera>().enabled = true;//Turn on the camera
		myPlayer.GetComponentInChildren<AudioListener> ().enabled = true;//Turn on the Audio Listener

	}

}
