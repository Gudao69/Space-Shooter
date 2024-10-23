using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        int score;
        score = PlayerPrefs.GetInt("MyScore");

        HighScoreText.text = "Highscore : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
