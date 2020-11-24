using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject rightCamera;
    public GameObject leftCamera;
    public GameObject firstPerson;

    public bool povToggle;

    private float axisValue;

    // Start is called before the first frame update
    void Start()
    {
        SetMainCamera();
    }

    // Update is called once per frame
    void Update()
    {
        // gets value of "Camera Position" value
        axisValue = Input.GetAxis("Camera Position");
        ToggleCamera();
    }

    // manages cameras based on axis values
    public void ToggleCamera()
    {
        if (axisValue > 0)
        {
            SetRightCamera();
        }
        else
        if (axisValue < 0)
        {
            SetLeftCamera();
        }
        else 
        if (axisValue == 0)
        {
            SetMainCamera();
        }
    }

    // Sets camera to the mainCamera
    void SetMainCamera()
    {
        mainCamera.SetActive(true);
        rightCamera.SetActive(false);
        leftCamera.SetActive(false);
    }

    // Sets camera to rightCamera
    void SetRightCamera()
    {
        mainCamera.SetActive(false);
        rightCamera.SetActive(true);
        leftCamera.SetActive(false);
    }

    // Sets camera to leftCamera
    void SetLeftCamera()
    {
        mainCamera.SetActive(false);
        rightCamera.SetActive(false);
        leftCamera.SetActive(true);
    }
}
