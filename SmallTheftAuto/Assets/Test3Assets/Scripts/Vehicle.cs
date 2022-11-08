using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float _currentMoveSpeed;
    public float CurrentMoveSpeed 
    {
        set { _currentMoveSpeed = Mathf.Clamp(value, -moveSpeed/2, moveSpeed); }
        get { return _currentMoveSpeed;  }
    }
    [SerializeField]
    private float handeling;
    [SerializeField]
    private float drifting;
    [SerializeField]
    private float acceleration;


    public ParticleSystem particleSystem;
    public ParticleSystem[] driftParticleSystem;
    public Renderer body;
    public Rigidbody rb;
    public GameObject driver;
    public CameraMovement cam;

    public float moveSpeedMin;
    public float moveSpeedMax;
    public float handelingMin;
    public float handelingMax;
    public float driftingMin;
    public float driftingMax;
    public float accelerationMin;
    public float accelerationMax;

    private float verticalInput;
    private float horizontalInput;

    public bool driving;
    public bool braking;
    private void Start()
    {
        body.material.color = Color.HSVToRGB(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
        handeling = Random.Range(handelingMin, handelingMax);
        acceleration = Random.Range(accelerationMin, accelerationMax);
        drifting = Random.Range(driftingMin, driftingMax);
        //transform.localScale = new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f));
    }
    void Simulate()
    {

        //this is what actually moves the vehicle
        particleSystem.emissionRate = Mathf.Pow(CurrentMoveSpeed, 2);
        rb.velocity = transform.forward * CurrentMoveSpeed;
        rb.angularVelocity = new Vector3(0, 0, 0);
        if (!driving)
        {
            LoseMomentum();
        }
    }
    void LoseMomentum()
    {

        if (CurrentMoveSpeed > 0)
        {
            CurrentMoveSpeed = CurrentMoveSpeed - (Time.fixedDeltaTime * (acceleration));
        }
        else
        {
            CurrentMoveSpeed = CurrentMoveSpeed + (Time.fixedDeltaTime * (acceleration));
        }
    }
    void Drive()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            braking = true;
            for (int i = 0; i < 4; i++)
            {
                driftParticleSystem[i].Play();
                driftParticleSystem[i].emissionRate = Mathf.Pow(CurrentMoveSpeed, 2.2f);
            }
        }
        else
        {
            braking = false;
            for (int i = 0; i < 4; i++)
            {
                driftParticleSystem[i].Stop();
                driftParticleSystem[i].emissionRate = Mathf.Pow(CurrentMoveSpeed, 2.2f);
            }
        }
        if (horizontalInput > .1f)
        {
            if (braking)
            {
                transform.Rotate(0f, (handeling * Time.fixedDeltaTime) * (CurrentMoveSpeed / moveSpeed)*drifting, 0f);
            }
            else
            {
                transform.Rotate(0f, (handeling * Time.fixedDeltaTime) * (CurrentMoveSpeed / moveSpeed), 0f);
            }
        }
        if (horizontalInput < -.1f)
        {
            if (braking)
            {
                transform.Rotate(0f, -(handeling * Time.fixedDeltaTime) * (CurrentMoveSpeed / moveSpeed) * drifting, 0f);
            }
            else
            {
                transform.Rotate(0f, -(handeling * Time.fixedDeltaTime) * (CurrentMoveSpeed / moveSpeed), 0f);
            }
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        CurrentMoveSpeed += verticalInput * Time.fixedDeltaTime * acceleration;
        if (Mathf.Abs(verticalInput) < .1f)
        {
            LoseMomentum();
        }
        if (braking)
        {
            if (CurrentMoveSpeed > 0)
            {
                CurrentMoveSpeed = CurrentMoveSpeed - (Time.fixedDeltaTime * (acceleration) * drifting);
            }
            else
            {
                CurrentMoveSpeed = CurrentMoveSpeed + (Time.fixedDeltaTime * (acceleration) * drifting);
            }
        }
        //transform.Translate(0, 0, CurrentMoveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            driver.SetActive(true);
            driving = false;
            driver.GetComponent<Driver>().inCar = true;
            cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(18, 13, 20), cam.offset.z);
            //cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(18, 10, 20), Mathf.Lerp(-14, 0, 20));
            //cam.transform.eulerAngles = new Vector3(Mathf.Lerp(45, 90, 20), cam.transform.rotation.y, cam.transform.rotation.z);
            particleSystem.emissionRate = 0;
        }
    }
    void FixedUpdate()
    {
        if (driving)
        {
            Drive();
        }
        Simulate();
    }

}
