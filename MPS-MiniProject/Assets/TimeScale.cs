using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [Range(0.0f,100.0f)]
    public float SpeedOfTime = 1;
    void FixedUpdate()
    {
        Time.timeScale = SpeedOfTime;
    }
}
