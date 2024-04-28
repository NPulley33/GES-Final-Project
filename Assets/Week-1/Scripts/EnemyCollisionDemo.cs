using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class EnemyCollisionDemo : MonoBehaviour
{
    public Material matDamaged;
    public Material matNormal;

    private MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }


    //on collison enter takes a diff argument
    //this is for listening to triggers
    private void OnTriggerEnter(Collider other)
    {
        //if other.gameObject.tag
        if (other.gameObject.name == "Bullet")
        {
            mr.material = matDamaged;

            //timer, called after a delay
            //time to wait, doce to execute (lambda, creates a method on the fly), 
            DOVirtual.DelayedCall(0.1f, () => {
                //add what to do
                mr.material = matNormal;
            } );     
        }
    }

    //called every frame while in trigger
    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    //this is for listening to physics
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void Damage() {
        Debug.Log("Damaged");
    }

}
