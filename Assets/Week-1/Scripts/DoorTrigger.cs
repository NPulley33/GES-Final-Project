using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float openSpeedModifier;

    Vector3 origin;
    Vector3 target;

    private bool isOpening;
    private float alpha;

    private void Awake()
    {
        origin = door.transform.position;
        target = origin + (Vector3.up * 5);
    }

    private void Update()
    {
        //Lerping
        alpha += isOpening ? Time.deltaTime * openSpeedModifier : -Time.deltaTime * openSpeedModifier;
        alpha = Mathf.Clamp01(alpha); //if value is < 0 or > 1 changes to max or min

        door.transform.position = Vector3.Lerp(origin, target, alpha);
    }


    private void OnTriggerEnter(Collider other)
    {
        isOpening = true;
        //door.gameObject.SetActive(false);
        //door.transform.position = transform.position + (Vector3.up * 10);  
    }

    private void OnTriggerExit(Collider other)
    {
        isOpening = false;
        //door.gameObject.SetActive(true);
        //door.transform.position = origin;
    }

}
