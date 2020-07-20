// Controling the Main Menu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Load other scenes
    public void GoToPlayGame () {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main");
    }
    public void GoToMainMenu() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void OpenMyGithub() {
        Application.OpenURL("https://github.com/DanBullockCS");
    }
    public void QuitGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
