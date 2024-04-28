using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] int Points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Debug.Log("Hit Target");
            //get rid of target piece
            //update player score (somehow)
            Player player = FindAnyObjectByType(typeof(Player)) as Player;
            player.UpdateScore(Points);
        }
    }

}
