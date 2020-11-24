using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColorScript : MonoBehaviour
{
    private BackroundManager backroundManager;
    private Color lightColor;

    private Color keplerColor = new Color(14, 25, 81, 100);
    private Color pegasiColor = new Color(351, 13, 84, 100);
    private Color cancriColor = new Color(32, 28, 94, 100);

    // Start is called before the first frame update
    void Start()
    {
        backroundManager = GameObject.Find("BackroundManager").GetComponent<BackroundManager>();
        lightColor = GameObject.Find("Directional Light").GetComponent<Light>().color;
    }

    // Update is called once per frame
    void Update()
    {
        LightColorManager();
    }

    void LightColorManager()
    {
        if (backroundManager.keplerSelected)
        {
            lightColor = keplerColor;
        }
        else
        if (backroundManager.pegasiSelected)
        {
            lightColor = pegasiColor;
        }
        else
        if (backroundManager.cancriSelected)
        {
            lightColor = cancriColor;
        }
    }
}
