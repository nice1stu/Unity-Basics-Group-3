using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float _currentMoveSpeed;
    private float CurrentMoveSpeed 
    {
        set { _currentMoveSpeed = Mathf.Clamp(value, -moveSpeed/2, moveSpeed); }
        get { return _currentMoveSpeed;  }
    }
    [SerializeField]
    private float handeling;
    [SerializeField]
    private float acceleration;

    public Renderer body;
    public Rigidbody rb;
    public GameObject driver;
    public CameraMovement cam;

    public float moveSpeedMin;
    public float moveSpeedMax;
    public float handelingMin;
    public float handelingMax;
    public float accelerationMin;
    public float accelerationMax;

    private float verticalInput;
    private float horizontalInput;

    public bool driving;
    private void Start()
    {
        body.material.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.7f, .8f);
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        handeling = Random.Range(handelingMin, handelingMax);
        acceleration = Random.Range(accelerationMin, accelerationMax);
    }
    void drive()
    {

        if (horizontalInput > .1f)
        {
            transform.Rotate(0f, (handeling * Time.deltaTime) * (CurrentMoveSpeed / moveSpeed), 0f);
        }
        if (horizontalInput < -.1f)
        {
            transform.Rotate(0f, -(handeling * Time.deltaTime) * (CurrentMoveSpeed / moveSpeed), 0f);
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (verticalInput > .1f)
        {
            CurrentMoveSpeed = CurrentMoveSpeed + Time.deltaTime * acceleration;
        }
        else if (verticalInput < -.1f)
        {
            CurrentMoveSpeed = CurrentMoveSpeed - Time.deltaTime * acceleration;
        }
        else
        {
            if (CurrentMoveSpeed > 0)
            {
                CurrentMoveSpeed = CurrentMoveSpeed - (Time.deltaTime * (acceleration));
            }
            else
            {
                CurrentMoveSpeed = CurrentMoveSpeed + (Time.deltaTime * (acceleration));
            }
        }
        //this is what actually moves the vehicle
        rb.velocity = transform.forward * CurrentMoveSpeed;
        rb.angularVelocity = new Vector3(0,0,0);
        //transform.Translate(0, 0, CurrentMoveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            driver.SetActive(true);
            driving = false;
            driver.GetComponent<Driver>().inCar = true;
            cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(18, 10, 20), cam.offset.z);
            //cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(18, 10, 20), Mathf.Lerp(-14, 0, 20));
            //cam.transform.eulerAngles = new Vector3(Mathf.Lerp(45, 90, 20), cam.transform.rotation.y, cam.transform.rotation.z);
        }
    }
    void Update()
    {
        if (driving)
        {
            drive();
        }
    }

}
