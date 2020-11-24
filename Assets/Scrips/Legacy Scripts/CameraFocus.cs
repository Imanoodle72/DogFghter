using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    private float minFov = 25f;
    private float standardFov = 60f;
    private float originalFov;

    private float zoomSpeed = 2.5f;
    public bool isZoomed;

    private Camera mainCamera;
    private float fov;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        originalFov = standardFov;

        mainCamera = Camera.main;
        zoomSpeed *= 100;
    }

    // Update is called once per frame
    void Update()
    {
        fov = mainCamera.fieldOfView;

        ZoomZoom();
    }

    void ZoomZoom()
    {
        if (Input.GetMouseButton(1))
        {
            fov = fov - zoomSpeed * Time.deltaTime;
            isZoomed = true;
        }
        else
        {
            fov = fov + zoomSpeed * Time.deltaTime;
            isZoomed = false;
        }

        ZoomLimit();
    }

    void SpeedZoom()
    {
        if (playerController.throttleLevel == 5f)
        {
            standardFov = originalFov + 5f;
        }
        else
        if (playerController.throttleLevel == 4f)
        {
            standardFov = originalFov + 2.5f;
        }
        else
        if (playerController.throttleLevel == 3f)
        {
            standardFov = originalFov;
        }
        else
        if (playerController.throttleLevel == 2f)
        {
            standardFov = originalFov - 2.5f;
        }
        else
        if (playerController.throttleLevel == 1f)
        {
            standardFov = originalFov - 5f;
        }
    }

    void ZoomLimit()
    {
        if (fov > standardFov)
        {
            SpeedZoom();
            fov = standardFov;
        }
        else
        if (fov < minFov)
        {
            fov = minFov;
        }

        mainCamera.fieldOfView = fov;
    }
}
