using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    [SerializeField] int Points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {            //get rid of target piece
            Destroy(gameObject);
            //update player score
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().UpdateScore(Points);
        }
    }

}
