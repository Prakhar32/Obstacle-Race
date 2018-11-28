using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static float time;
    public Canvas WinCanvas;
    public Canvas LoseCanvas;
    public TextMeshProUGUI tmPro;
    private static int PinCollision;
    private static int RodCollision;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI PinText;
    public TextMeshProUGUI RodText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public float TimeWeight;
    public float PinWeight;
    public float RodWeight;
    public int HighScore;
    
	// Use this for initialization
	void Start () {
		time = 0.0f;
        HighScore = PlayerPrefs.GetInt("HighScore");
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        tmPro.text = "Time : " + (int)time;
	}

    public static void Obstacle1Collision()
    {
        PinCollision++;
    }

    public static void Obstacle2Collision()
    {
        RodCollision++;
    }

    public void Win()
    {
        TimeText.text = "" + (int)time;
        PinText.text = "" + PinCollision;
        RodText.text = "" + RodCollision;
        float Score = - PinCollision * PinWeight - RodCollision * RodWeight + (int)Mathf.Max((TimeWeight - time), 0);
        ScoreText.text = "" + (int)Mathf.Max(Score, 0);
        WinCanvas.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("HighScore") < Score)
            PlayerPrefs.SetInt("HighScore", (int)Score);
        HighScoreText.text = "" + PlayerPrefs.GetInt("HighScore");
        Time.timeScale = 0;
    }

    public void Lose()
    {
        LoseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Scenes/GameScene");
        Time.timeScale = 1;
    }
}
