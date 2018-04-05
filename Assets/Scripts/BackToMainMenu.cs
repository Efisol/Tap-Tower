using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour {

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
