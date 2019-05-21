using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAxisRotation : MonoBehaviour
{
    public float daysSpentRotating;
    public float speed = 1;

    void Update()
    {
        transform.Rotate(new Vector3 (0, speed / daysSpentRotating * Time.deltaTime, 0), Space.Self);
    }
}
