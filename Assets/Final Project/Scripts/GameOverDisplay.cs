using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] TextMeshProUGUI HighScoreTxt;
    [SerializeField] TextMeshProUGUI AccuracyTxt;
    [SerializeField] TextMeshProUGUI FinalScoreTxt;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("SCORE", 0);
        float accuracy = PlayerPrefs.GetFloat("ACCURACY", 0);
        //get player score, assign to text
        ScoreTxt.text = $"Score: {score}";
        //get player accuracy, assgn to text
        AccuracyTxt.text = $"Accuracy: {accuracy * 100: 0.0}%";
        //multiply score by accuracy to get final score, assgn to text
        float finalScore = score * accuracy;
        FinalScoreTxt.text = $"Final Score: {finalScore: 0.0}";

        //checks & assigns a high score
        if (finalScore < PlayerPrefs.GetFloat("HIGH SCORE", finalScore))
        {
            HighScoreTxt.text = $"High Score: {PlayerPrefs.GetFloat("HIGH SCORE", finalScore): 0.0}";
        }
        else
        {
            PlayerPrefs.SetFloat("HIGH SCORE", finalScore);
            PlayerPrefs.Save();
            HighScoreTxt.text = $"High Score: {PlayerPrefs.GetFloat("HIGH SCORE", finalScore): 0.0}";
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }

}
