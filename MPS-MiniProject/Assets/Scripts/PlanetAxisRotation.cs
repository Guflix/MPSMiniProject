using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAxisRotation : MonoBehaviour
{

    public float degrPerSec;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, degrPerSec * Time.deltaTime);
    }
}
