using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Pause : MonoBehaviour {

    public void OnPauseClick()
    {
        Time.timeScale = 0;
    }

    public void OnBackClick()
    {
        Time.timeScale = 1;
    }

    public void OnRestartClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
