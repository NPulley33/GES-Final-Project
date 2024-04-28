using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNav : MonoBehaviour
{

    [SerializeField] GameObject MainMenuObjects;
    [SerializeField] GameObject CreditsObjects;
    [SerializeField] GameObject InstructionObjects;


    public void StartPressed()
    {
        //disable main menu elements
        MainMenuObjects.SetActive(false);
        //enable how to play elements
        InstructionObjects.SetActive(true);
    }

    public void PlayPressed()
    {
        //load first level
        SceneManager.LoadScene("Level_01");
    }

    public void CreditsPressed()
    { 
        //dissable main menu elements
        MainMenuObjects.SetActive(false);
        //enable credits text elements
        CreditsObjects.SetActive(true);
    }

    public void BackPressed()
    {
        //disable credits text elements
        CreditsObjects.SetActive(false);
        //enable main menu elements
        MainMenuObjects.SetActive(true);
    }

}