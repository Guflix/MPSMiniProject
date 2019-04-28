using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    const double gravityConstant = 667.408; //0.0000000000667408; // Newtonian gravitational constant https://simple.wikipedia.org/wiki/Gravitational_constant

    public static List<PlanetPhysics> planets;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        foreach (PlanetPhysics obj in planets)
        {
            if (obj != this)
                PhysicsAttraction(obj);
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

    void PhysicsAttraction(PlanetPhysics objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        if (distance == 0f) // If you duplicate a planet, just make sure not to run the rest of the code
            return;

        float forceMagnitude = ((float)gravityConstant*((rb.mass * rbToAttract.mass) / (distance * distance)));
        Vector3 pullForce = direction.normalized * forceMagnitude;

        //// TODO: Implement Sideways Force to generate an actual orbit
        //Vector3 sidewaysForce =

        rbToAttract.AddForce(pullForce);
    }
}
