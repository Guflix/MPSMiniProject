using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetPhysics : MonoBehaviour
{
    [HideInInspector] public Rigidbody rb;
    const double gravityConstant = 0.3; //0.667408; //0.0000000000667408; // Newtonian gravitational constant https://simple.wikipedia.org/wiki/Gravitational_constant

    public static List<PlanetPhysics> planets;
    public float startVelocity = 1;
    public float realDistanceToSun;
    Vector3 startingPos;

    LineRenderer lr;
    [Range(1,500)]
    public int lineSegments = 100;


    void Start()
    {
        startingPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, startVelocity);
        lr = GetComponent<LineRenderer>();
        CreateOrbitPath();
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

        rbToAttract.AddForce(pullForce);
    }

    void CreateOrbitPath()
    {
        Vector3[] points = new Vector3[lineSegments + 1];
        for (int i = 0; i < points.Length; i++)
        {
            float angle = ((float)i / (float)(lineSegments)) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin(angle) * startingPos.x; // What should this value be?
            float z = Mathf.Cos(angle) * startingPos.x;
            points[i] = new Vector3(x, 0f, z);
        }
        points[lineSegments] = points[0];
        lr.positionCount = lineSegments + 1;
        lr.SetPositions(points);
    }

    void OnValidate()
    {
        if (Application.isPlaying)
            CreateOrbitPath();
    }
}
