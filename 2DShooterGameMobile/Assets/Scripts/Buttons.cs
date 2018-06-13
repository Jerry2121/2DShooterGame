using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    public GameObject PauseCanvas;
    public GameObject WarningCanvas;
    public GameObject PauseButtons;
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
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("lvlnum", 1);
        PlayerPrefs.SetInt("lvl1c", 0);
        PlayerPrefs.SetInt("lvl2c", 0);
        SceneManager.LoadScene("transition");
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
        WarningCanvas.GetComponent<Canvas>().enabled = true;
        PauseButtons.gameObject.SetActive(false);

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
    public void Yes()
    {
        PlayerPrefs.SetInt("Health", 10);
        PlayerPrefs.SetInt("Coins", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void No()
    {
        WarningCanvas.GetComponent<Canvas>().enabled = false;
        PauseButtons.gameObject.SetActive(true);
    }
}
