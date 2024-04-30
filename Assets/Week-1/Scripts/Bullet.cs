using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private void Awake()
    {
        //using this vs gameObject only destroys the script component
        //adding 8f means that after 8 seconds it will destroy itself if it isn't told to sooner
        Destroy(gameObject, 8f);
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
