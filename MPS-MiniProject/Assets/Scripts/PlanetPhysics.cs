using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    Rigidbody rb;
    const float gravityConstant = 0.0000000000667408; // Newtonian gravitational constant https://simple.wikipedia.org/wiki/Gravitational_constant
    const float sunMass = 0;
    public float mass;
    public float distanceToSun; // 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    void Update()
    {
        Vector3 gravityForce = gravityConstant((sunMass * mass) / distanceToSun * distanceToSun);
        //Vector3 sidewaysForce =
    }
}
