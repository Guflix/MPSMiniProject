using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    public float SpeedOfTime = 1;
    void FixedUpdate()
    {
        Time.timeScale = SpeedOfTime;
    }
}
