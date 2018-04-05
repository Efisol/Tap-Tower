using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Menu : MonoBehaviour {
    
    public Button play;
    public Button quit;

	// Use this for initialization
	void Start () {
        play.onClick.AddListener(OnPlayClick);
        quit.onClick.AddListener(OnQuitClick);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnPlayClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void OnQuitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

}
