using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoomNameScript : MonoBehaviour
{

    public string m_RoomName = "";
    public InputField inputField;

 
    
    
    // Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_RoomName = inputField.text; 
	}

    public void JoinGame()
    {
        SceneManager.LoadScene("Multiplayer Final");
    }
    
}
