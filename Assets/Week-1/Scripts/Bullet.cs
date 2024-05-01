using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public bool hasCollided;

    private void Awake()
    {
        //using this vs gameObject only destroys the script component
        //adding 8f means that after 8 seconds it will destroy itself if it isn't told to sooner
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
        if (other.tag == "Target")
        { 
            hasCollided = true;
            Debug.Log(hasCollided + "bullet");
            Target target = other.GetComponent<Target>();

            target.PlaySound();

            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().UpdateScore(target.Points);

            Destroy(other.gameObject);
            
        }
    }
}
