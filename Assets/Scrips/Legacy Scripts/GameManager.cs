using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    [Space(10)]
    [Header("Lists")]
    public List<GameObject> targets;

    [Header("Texts")]
    [Header("UI Management")]
    // Play UI
    public TextMeshProUGUI killText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI targetNumber;
    public TextMeshProUGUI enemyNumber;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI throttleText;
    // Menu UI
    public TextMeshProUGUI titleText;

    [Header("(UI)Images")]
    public Image crosshair;
    public Image cursor;

    [Header("Buttons")]
    public Button restartButton;
    public Button deployButton;

    [Space(10)]
    [Header("Camera Management")]
    public GameObject mainCamera;
    public GameObject rightCamera;
    public GameObject leftCamera;

    private int kills;
    private int wave;
    private int numTargets;
    private int numEnemies;
    private int health;
    private int speedIndicator;

    private SpawnManager spawnManager;

    void Start()
    {
        spawnManager = GameObject.Find("ObstacleSpawnManager").GetComponent<SpawnManager>();
        spawnManager.enabled = false;

        MenuConditions(false);
    }

    // Update is called once per frame
    void Update()
    {
        CursorStatus();
    }

    public void StartGame()
    {
        isGameActive = true;
        
        spawnManager.enabled = true;

        PlayUI(true);

        kills = 0;
        wave = 1;

        UpdateKill(0);
        UpdateWave(0);
    }

    void CursorStatus()
    {
        if (isGameActive)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }

    // MenuConditions(false)
    public void MenuConditions(bool setStatus)
    {
        /* Shows Play UI */
        // Texts
        killText.gameObject.SetActive(setStatus);
        waveText.gameObject.SetActive(setStatus);
        targetNumber.gameObject.SetActive(setStatus);
        enemyNumber.gameObject.SetActive(setStatus);
        healthText.gameObject.SetActive(setStatus);
        speedText.gameObject.SetActive(setStatus);
        throttleText.gameObject.SetActive(setStatus);
        // Buttons
        crosshair.gameObject.SetActive(setStatus);
        cursor.gameObject.SetActive(setStatus);

        isGameActive = setStatus;
    }

    // PlayUI(true)
    public void PlayUI(bool setStatus)
    {
        /* Shows Play UI */
        // Texts
        killText.gameObject.SetActive(setStatus);
        waveText.gameObject.SetActive(setStatus);
        targetNumber.gameObject.SetActive(setStatus);
        enemyNumber.gameObject.SetActive(setStatus);
        healthText.gameObject.SetActive(setStatus);
        speedText.gameObject.SetActive(setStatus);
        // Buttons
        crosshair.gameObject.SetActive(setStatus);
        cursor.gameObject.SetActive(setStatus);
        throttleText.gameObject.SetActive(setStatus);
        /* Hids Menu UI */
        // Texts
        titleText.gameObject.SetActive(!setStatus);
        // Buttons
        deployButton.gameObject.SetActive(!setStatus);

        isGameActive = setStatus;
    }

    // used by PlayerOnLaser script: GameOver(true)
    public void GameOver(bool setStatus)
    {
        gameOverText.gameObject.SetActive(setStatus);
        restartButton.gameObject.SetActive(setStatus);

        /* Shows Play UI */
        // Texts
        killText.gameObject.SetActive(!setStatus);
        waveText.gameObject.SetActive(!setStatus);
        targetNumber.gameObject.SetActive(!setStatus);
        enemyNumber.gameObject.SetActive(!setStatus);
        healthText.gameObject.SetActive(!setStatus);
        speedText.gameObject.SetActive(!setStatus);
        throttleText.gameObject.SetActive(!setStatus);
        // Buttons
        crosshair.gameObject.SetActive(!setStatus);
        cursor.gameObject.SetActive(!setStatus);
        isGameActive = !setStatus;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    public void UpdateThrottle(int throttleValue)
    {
        throttleText.text = "THROTTLE: " + throttleValue;
    }

    public void UpdateSpeed(float speedValue)
    {
        speedIndicator = (int)speedValue;
        speedText.text = "SPEED: " + speedIndicator + " U/SEC";
    }

    public void UpdateHealth(int healthValue)
    {
        health = healthValue;
        healthText.text = "HULL INTEGRITY: " + health;
    }

    public void UpdateTargets(int targetQuantity)
    {
        numTargets = targetQuantity;
        targetNumber.text = "TARGETS: " + numTargets;
    }

    public void UpdateEnemies(int enemyQuantity)
    {
        numEnemies = enemyQuantity;
        enemyNumber.text = "ENEMIES: " + numEnemies;
    }

    public void UpdateKill(int killToAdd)
    {
        kills += killToAdd;
        killText.text = "KILLS: " + kills;
    }

    public void UpdateWave(int waveToAdd)
    {
        wave += waveToAdd;
        waveText.text = "WAVE: " + wave;
    }
}
