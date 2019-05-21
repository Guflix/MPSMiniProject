using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleText : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();   
    }

    public void TextUpdate(float value)
    {
        text.text = value.ToString() + "x";
    }
}
