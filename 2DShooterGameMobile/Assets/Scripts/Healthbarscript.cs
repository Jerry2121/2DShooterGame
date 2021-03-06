﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbarscript : MonoBehaviour {
    public Slider Healthbar;
    public GameObject Lives;
    public GameObject Coins;

	// Use this for initialization
	void Start () {
        Coins.GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("Coins");
        Lives.GetComponent<Text>().text = "Lives: " + PlayerPrefs.GetInt("Lives");
        Healthbar.value = PlayerPrefs.GetInt("Health");
	}
	
	// Update is called once per frame
	void Update () {
        Healthbar.value = PlayerPrefs.GetInt("Health");
        Coins.GetComponent<Text>().text = "Coins: " + PlayerPrefs.GetInt("Coins");
        if (PlayerPrefs.GetInt("Health") <= 0)
        {
            PlayerPrefs.SetInt("Health", 10);
            SceneManager.LoadScene("transition");
            PlayerPrefs.SetInt("Lives", PlayerPrefs.GetInt("Lives") - 1);
            Lives.GetComponent<Text>().text = "Lives: " + PlayerPrefs.GetInt("Lives");
        }
        if (PlayerPrefs.GetInt("Lives") <= 0)
        {
            SceneManager.LoadScene("Loose");
        }
    }
}
