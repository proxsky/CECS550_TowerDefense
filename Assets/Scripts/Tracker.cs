﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour {

    public static int lives;
    public static int money;
    public static int waveCount;

    public Text livesText;
    public Text moneyText;
    public Text waveText;

    public bool gameOver;
    public GameObject gameOverMenu;
 

	// Use this for initialization
	void Start () {

        waveCount = 0;
        lives = 5;
        money = 100;
        gameOver = false;
        Time.timeScale = 1;

        livesText.text = lives.ToString();
        moneyText.text = money.ToString();
        waveText.text = "WAVE " + waveCount.ToString();

	}
	
	// Update is called once per frame
	void Update () {

        if(lives<=0)
        {
            lives = 0;
            Time.timeScale = 0;
            gameOver = true;
            gameOverMenu.SetActive(gameOver);
        }

        livesText.text = lives.ToString();
        moneyText.text = money.ToString();
        waveText.text = "WAVE " + waveCount.ToString();
    }
}
