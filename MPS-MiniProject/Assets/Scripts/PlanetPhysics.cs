using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    double gravityConstant = 0.0000000000667408; // Newtonian gravitational constant https://simple.wikipedia.org/wiki/Gravitational_constant

    public static List<PlanetPhysics> planets;
    public float startVelocity = 1;
    public double realDistanceToSun, actualMass;
    public bool useRealDistanceToSun = false;
    Vector3 startingPos;


    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, startVelocity);

        /// Scaling
        if (realDistanceToSun != 0)
            realDistanceToSun = realDistanceToSun / 1e6;
        if (useRealDistanceToSun)
            transform.position = new Vector3((float)realDistanceToSun, 0, 0);
        if (actualMass != 0)
            rb.mass = (float)actualMass / (float)1e27;
        gravityConstant = gravityConstant / (float)1e-10;
    }

    void FixedUpdate()
    {
        foreach (PlanetPhysics obj in planets)
        {
            if (obj != this || obj.tag != "Sun" ) // Don't try to make a planet pull itself or the sun (sun is static)
                PhysicsAttraction(obj);
        }
    }

    void PhysicsAttraction(PlanetPhysics objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;
        Vector3 direction = rb.position - rbToAttract.position;

        double distance = direction.magnitude;

        if (distance == 0f) // If you duplicate a planet, just make sure not to run the rest of the code
            return;

        if (tag == "Sun" || distance < 500) // Don't try to attract the sun, it is static, and don't bother attracting objets far away
        {
            double forceMagnitude = (gravityConstant*((rb.mass * rbToAttract.mass) / (distance * distance)));
            Vector3 pullForce = direction.normalized * (float)forceMagnitude;
            rbToAttract.AddForce(pullForce);
        }
    }

    void OnEnable() // On enable and on disable isn't really useful for this implementation, but more so for instantiating and removing planets during runtime
    {
        if (planets == null)
            planets = new List<PlanetPhysics>();

        planets.Add(this);
    }

    void OnDisable()
    {
        planets.Remove(this);
    }
}
