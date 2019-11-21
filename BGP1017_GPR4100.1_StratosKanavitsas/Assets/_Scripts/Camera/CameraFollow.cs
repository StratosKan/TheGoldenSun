using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    void QuitButtonClicked()
    {
        Debug.Log("Quit has been clicked.");
    }

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        //Time.deltaTime γιατί δεν θέλουμε να αλλάζει η κάμερα 50 φορές το δευτερόλεπτο.                             
    }

}
