using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class transitionscreen : MonoBehaviour {
    public GameObject livestext;
    public GameObject Leveltext;
    private float Timer;
	// Use this for initialization
	void Start () {
        livestext.GetComponent<Text>().text = "Lives: " + PlayerPrefs.GetInt("Lives");
        Leveltext.GetComponent<Text>().text = "Level " + PlayerPrefs.GetInt("lvlnum") + " ------------------";

    }
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        if(PlayerPrefs.GetInt("lvlnum") == 4)
        {
            SceneManager.LoadScene("Win");
        }
        if(Timer >= 2)
        {
            if (PlayerPrefs.GetInt("lvlnum") == 1)
            {
                livestext.GetComponent<Text>().text = "Lives: " + PlayerPrefs.GetInt("Lives");
                Leveltext.GetComponent<Text>().text = "Level " + PlayerPrefs.GetInt("lvlnum") + " ------------------";
                PlayerPrefs.SetInt("lvl1c", 0);
                SceneManager.LoadScene("lvl1");
            }
            if (PlayerPrefs.GetInt("lvlnum") == 2)
            {
                SceneManager.LoadScene("lvl2");
            }
            if (PlayerPrefs.GetInt("lvlnum") == 3)
            {
                SceneManager.LoadScene("lvl3");
            }
        }
	}
}
