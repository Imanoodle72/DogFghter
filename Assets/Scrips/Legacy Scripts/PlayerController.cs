using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Customization")]
    public float throttle;
    public float xTurnRate;
    public float yTurnRate;
    public float rollSpeed;
    public float deadZone;
    private float originalThrottle;
    
    
    [Header("Input Detection")]
    public float xMousePosition;
    public float yMousePosition;
    public float speed;

    private Rigidbody playerRB;
    private float horizontalInput;
    private float verticalInput;
    private float rollInput;
    private Vector3 lastPosition = Vector3.zero;
    private float bounce = .5f;
    

    [Header("Other")]
    public bool isZoomed;
    public float zoomIntensity;
    private float xZoomedTurnRate;
    private float yZoomedTurnrate;

    private GameManager gameManager;
    private CameraFocus cameraFocus;

    public int throttleLevel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cameraFocus = GameObject.Find("Main Camera").GetComponent<CameraFocus>();
        playerRB = GetComponent<Rigidbody>();

        originalThrottle = throttle;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.UpdateThrottle(throttleLevel);

        xZoomedTurnRate = xTurnRate / zoomIntensity;
        yZoomedTurnrate = yTurnRate / zoomIntensity;

        isZoomed = cameraFocus.isZoomed;

        if (gameManager.isGameActive == true)
        {
            TurnApplications();
            ThrustControl();
            Thrust();
        }
    }

    void FixedUpdate()
    {
        DetectSpeed();
        gameManager.UpdateSpeed(speed);
    }

    void DetectSpeed()
    {
        // Detect speed
        speed = ((transform.position - lastPosition).magnitude) * 100;
        lastPosition = transform.position;
    }

    void YawConfiguration()
    {
        // Distance from the center
        float yaw = (xMousePosition - (Screen.width / 2f));
        if (yaw > deadZone || yaw < -deadZone)
        {
            horizontalInput = yaw;
        } else
        {
            horizontalInput = 0;
        }
    }

    void PitchConfiguration()
    {
        float pitch = -(yMousePosition - (Screen.height / 2f));

        if (pitch > deadZone || pitch < -deadZone)
        {
            verticalInput = pitch;
        }else
        {
            verticalInput = 0;
        }
    }

    void RollConfiguration()
    {
        rollInput = -(Input.GetAxis("Horizontal") * rollSpeed);
    }

    void TurnApplications()
    {
        YawConfiguration();
        PitchConfiguration();
        RollConfiguration();

        xMousePosition = Input.mousePosition.x;
        yMousePosition = Input.mousePosition.y;

        TorqueApplications();
    }

    void TorqueApplications()
    {
        if (isZoomed == true)
        {
            playerRB.AddTorque(gameObject.transform.up * horizontalInput * xZoomedTurnRate * Time.deltaTime);   // Yaw
            playerRB.AddTorque(gameObject.transform.right * verticalInput * yZoomedTurnrate * Time.deltaTime);  // Pitch
        }
        else
        {
            playerRB.AddTorque(gameObject.transform.up * horizontalInput * xTurnRate * Time.deltaTime);   // Yaw
            playerRB.AddTorque(gameObject.transform.right * verticalInput * yTurnRate * Time.deltaTime);  // Pitch
        }

        playerRB.AddTorque(gameObject.transform.forward * rollInput * Time.deltaTime);         // Roll
    }

    public void ThrustControl()
    {
        // Applies throttle controls
        if (Input.GetAxis("Throttle") > 0)
        {
            throttleLevel ++;
        }
        else
        if (Input.GetAxis("Throttle") < 0)
        {
            throttleLevel --;
        }
        else
        if (Input.GetKey("r"))
        {
            throttleLevel = 3;
        }

        // Prevents throttle from exeeding parameters (1 to 5)
        if (throttleLevel > 5)
        {
            throttleLevel = 5;
        }
        else
        if (throttleLevel < 1)
        {
            throttleLevel = 1;
        }
    }

    public void Thrust()
    {
        float thrustMultiplier = 15.971f;
        if (throttleLevel == 5)
        {
           throttle = originalThrottle + 1f;
        }
        else
        if (throttleLevel == 4)
        {
            throttle = originalThrottle + .5f;
        }
        else
        if (throttleLevel == 3)
        {
            throttle = originalThrottle;
        }
        else
        if (throttleLevel == 2)
        {
        throttle = originalThrottle - .5f;
        }
        else
        if (throttleLevel == 1)
        {
            throttle = originalThrottle - 1f;
        }
        // Adds thrust to the Game Object
        playerRB.AddForce(playerRB.transform.forward * throttle * Time.deltaTime * thrustMultiplier, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("LaserP"))
        {
            Vector3 awayFromTarget = transform.position - other.gameObject.transform.position;
            playerRB.AddForce(awayFromTarget * bounce, ForceMode.Impulse);
        }
        else
        {
            Vector3 awayFromTarget = transform.position - other.gameObject.transform.position;
            playerRB.AddForce(awayFromTarget * 0, ForceMode.Impulse);
        }
    }

}
