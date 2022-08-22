using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;

    private int score;
    [SerializeField] private Text textScore;
    private int highScore;
    [SerializeField] private Text textHighScore;
    [SerializeField] private GameObject button;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Time.timeScale = 1f;
        //score
        score = 0;
        textScore.text = score.ToString();
        //high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        textHighScore.text = highScore.ToString();
        //button
        button.SetActive(false);
    }
    public void AddScore(int s)
    {
        score += s;
        textScore.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            textHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        HighScore();
        Time.timeScale = 0f;
        button.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene("Scene");
        AdsManager.instance.PlayAd();
    }
    private void HighScore()
    {
        if (int.Parse(textScore.text) > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", int.Parse(textScore.text));
            textHighScore.text = textScore.text;
        }
    }
}
