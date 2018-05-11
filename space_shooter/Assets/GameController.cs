﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;
    public Text scoreText;

    public Text gameOverText;
    private bool gameOver;

    public Text restartText;
    private bool restart;

	// Use this for initialization
	void Start () {
        gameOverText.text = "";
        gameOver = false;
        restartText.text = "";
        restart = false;
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void addScore(int value) {
        score += value;
        UpdateScore();
    }
    IEnumerator SpawnWaves() {

        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < hazardCount; i++) {
            while (true) {
                Vector3 spawnPostion = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPostion, spawnRotation);

                yield return new WaitForSeconds(spawnWait);

                if (gameOver)
                {
                    restart = true;
                    restartText.text = "Press 'R' to Restart";

                }
            }

            yield return new WaitForSeconds(waveWait);
        }
        
    }

    public void GameOver() {
        gameOver = true;
        gameOverText.text = "Game Over";
    }
}
