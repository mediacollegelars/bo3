using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingMousemovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.5f, 1f, 1.5f); // Optionele offset van de camera
    public Vector3 rotationOffset = new Vector3(20, 0, 0); // Optionele rotatie offset van de camera
    public float smoothness = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Bereken de gewenste positie van de camera (spelerpositie + offset)
            Vector3 targetPosition = target.position + offset;

            // Interpoleer de huidige positie van de camera naar de gewenste positie met een zachte overgang
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);
            Quaternion targetRotation = Quaternion.Euler(rotationOffset);

            // Pas de positie en rotatie van de camera aan
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothness);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smoothness);
        }
    }
}