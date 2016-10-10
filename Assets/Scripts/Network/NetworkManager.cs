using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class NetworkManager : MonoBehaviour {

	const string VERSION = "v0.0.1";
	public string roomName = "Stray";

	public GameObject playerPrefabName;
	public Camera camera;
	public Transform spawnPoint1;
	public Transform spawnPoint2;



	void Start () 
	{
		PhotonNetwork.ConnectUsingSettings (VERSION);//Connect to the lobby using the given settings

	}
	
	void OnJoinedLobby()
	{
		Debug.Log ("Lobby joined");

		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };//Create custom room options, here the room isn't visible to others and has 4 ppl max.
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);//Join or creat the room if it doesn't already exist.
	}

	void OnJoinedRoom()
	{
		//When you join the room, you create a clone of the Player prefab, and enable the Character Controller, FirstPersonController and Camera.
		//This is done to keep each individual clone independant if being run on the same machine (Excellent for playtesting and debugging)
		Debug.Log ("Room joined");

		GameObject myPlayer = PhotonNetwork.Instantiate (playerPrefabName.name, spawnPoint1.position, spawnPoint1.rotation, 0);

		myPlayer.GetComponent <CharacterController> ().enabled = true;
		myPlayer.GetComponent <FirstPersonController> ().enabled = true;
		myPlayer.GetComponentInChildren<Camera>().enabled = true;
		myPlayer.GetComponentInChildren<AudioListener> ().enabled = true;

	}

}
