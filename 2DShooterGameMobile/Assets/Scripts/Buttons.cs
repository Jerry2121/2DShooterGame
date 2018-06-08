using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public GameObject PauseCanvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartButton()
    {
        PlayerPrefs.SetInt("Lives", 3);
        PlayerPrefs.SetInt("Health", 10);
        SceneManager.LoadScene("lvl1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {
        PauseCanvas.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }
    public void Pause()
    {
        PauseCanvas.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
    }
}
