using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class BackroundManager : MonoBehaviour
{
    [Header("Materials")]
    public Material kepler;
    public Material pegasi;
    public Material cancri;

    [Header("Buttons")]
    public Button keplerButton;
    public Button pegasiButton;
    public Button cancriButton;

    public GameObject directionalLight;

    private GameManager gameManager;

    public bool keplerSelected;
    public bool pegasiSelected;
    public bool cancriSelected;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        keplerSelected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == false)
        {
            ButtonVisibility(true);
        }
        else
        {
            ButtonVisibility(false);
        }
    }

    void ButtonVisibility(bool setStatus)
    {
        keplerButton.gameObject.SetActive(setStatus);
        pegasiButton.gameObject.SetActive(setStatus);
        cancriButton.gameObject.SetActive(setStatus);
    }

    public void SelectKepler()
    {
        RenderSettings.skybox = kepler;
        keplerSelected = true;
        pegasiSelected = false;
        cancriSelected = false;
    }

    public void SelectPegasi()
    {
        RenderSettings.skybox = pegasi;
        keplerSelected = false;
        pegasiSelected = true;
        cancriSelected = false;
    }

    public void SelectCancri()
    {
        RenderSettings.skybox = cancri;
        keplerSelected = false;
        pegasiSelected = false;
        cancriSelected = true;
    }

    Vector3 LightTransformManager(Vector3 setRotation)
    {
        return setRotation;
    }
}
