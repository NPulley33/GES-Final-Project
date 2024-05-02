using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] public int Points;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Bullet")
        //{
        //    //find a way to check if bullet has already collided w/ smth
        //    if (other.gameObject.GetComponent<Bullet>().hasCollided == true) return;

        //    other.gameObject.GetComponent<Bullet>().hasCollided = true;

        //    //get rid of target piece
        //    Destroy(gameObject);

        //    //update player score
        //    GameObject player = GameObject.Find("Player");
        //    player.GetComponent<Player>().UpdateScore(Points);

        //    other.gameObject.GetComponent<Bullet>().hasCollided = false;
        //    Debug.Log(other.gameObject.GetComponent<Bullet>().hasCollided + "target");
        //}

        //play sound effect
    }

}
