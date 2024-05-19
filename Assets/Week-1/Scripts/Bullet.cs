using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public bool hasCollided;

    private void Awake()
    {
        //prevents stray bullets from going on forever if they don't collide w/ anything
        Destroy(gameObject, 8f);

        hasCollided = false;
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //check for what it has collided w/ and if it has already collided with an object
        if (other.tag == "Target" && hasCollided == false)
        { 
            hasCollided = true;
            Target target = other.GetComponent<Target>();

            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().UpdateScore(target.Points);

            Destroy(other.gameObject);
            
        }
    }
}
