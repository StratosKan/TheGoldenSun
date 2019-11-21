using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void MainScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }
    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
    public void LoadByIndex(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }
    public void QuitScene()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
    public void RestartCurrentScene()
    {
        Time.timeScale = 1;
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
