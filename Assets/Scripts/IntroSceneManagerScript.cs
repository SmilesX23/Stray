using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class IntroSceneManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("ArtProto"); 
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
