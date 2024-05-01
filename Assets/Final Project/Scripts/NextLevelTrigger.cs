using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] string NextLevel;

    //loads next scene when a player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            SceneManager.LoadScene(NextLevel);
        }
    }

}
