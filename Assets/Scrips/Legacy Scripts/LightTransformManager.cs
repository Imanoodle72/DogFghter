using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTransformManager : MonoBehaviour
{
    private BackroundManager backroundManager;

    private Vector3 keplerLightRotation = new Vector3(-7.149f, -177.09f, 17.257f);
    private Vector3 pegasiLightRotation = new Vector3(.097f, -180.05f, 17.249f);
    private Vector3 cancriLightRotation = new Vector3(.097f, -180.05f, 17.249f);

    // Start is called before the first frame update
    void Start()
    {
        backroundManager = GameObject.Find("BackroundManager").GetComponent<BackroundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        AngleConfirm();
    }

    void AngleConfirm()
    {
        if (backroundManager.keplerSelected)
        {
            // Quaternion Vector != Euler Vector
            AngleSetter(keplerLightRotation);
        }
        else
        if (backroundManager.pegasiSelected)
        {
            AngleSetter(pegasiLightRotation);
        }
        else
        if (backroundManager.cancriSelected)
        {
            AngleSetter(cancriLightRotation);
        }
    }

    void AngleSetter(Vector3 rotationSetter)
    {
        this.transform.rotation = Quaternion.Euler(rotationSetter);
    }
}
