using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAxisRotation : MonoBehaviour
{

    public float daysSpentRotating;
    public float speed = 1;


    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(Vector3.zero, Vector3.up, degrPerSec * Time.deltaTime);
        transform.Rotate(new Vector3 (0, speed / daysSpentRotating * Time.deltaTime, 0), Space.Self);
        
    }
}
