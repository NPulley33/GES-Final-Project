using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDisplay : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI ScoreTxt;
    [SerializeField] TextMeshProUGUI AccuracyTxt;
    [SerializeField] TextMeshProUGUI FinalScoreTxt;

    private void Start()
    {
        int score = PlayerPrefs.GetInt("SCORE", 0);
        float accuracy = PlayerPrefs.GetFloat("ACCURACY", 0);
        //get player score, assign to text
        ScoreTxt.text = $"Score: {score}";
        //get player accuracy, assgn to text
        AccuracyTxt.text = $"Score: {accuracy * 100}%";
        //multiply score by accuracy to get final score, assgn to text
        FinalScoreTxt.text = $"Final Score: {score * accuracy}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }

}
