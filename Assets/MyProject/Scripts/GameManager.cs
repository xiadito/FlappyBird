using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Singleton -> classe unica em todo jogo

    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] TextMeshProUGUI recordTXT;

    private int score;
    private int record;

    private void Awake()
    {
        instance = this;

        score = 0;
        record = PlayerPrefs.GetInt("Record", 0);

        UpdateScore();
        UpdateRecord();
    }

    public void AddScore()
    {
        //Sum score
        score++;
        UpdateScore();

        if (score > record)
        {
            record = score;
            PlayerPrefs.SetInt("Record", record);
            UpdateRecord();
        }
 
    }

    void UpdateScore()
    {
        scoreTXT.text = score.ToString("00");
    }

    void UpdateRecord()
    {
        
        recordTXT.text = record.ToString("0000"); 
    }

    public void GameOver()
    {
        Invoke("RestartGame", 2f);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
