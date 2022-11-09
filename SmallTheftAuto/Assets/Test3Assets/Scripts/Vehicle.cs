using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Vehicle : MonoBehaviour, ImFlammable
{
    public bool patrolling;
    bool onFire;
    private bool hasExploded = false;
    public GameObject fire;
    
    public float moveSpeed;
    private float _currentMoveSpeed;
    public float CurrentMoveSpeed 
    {
        set { _currentMoveSpeed = Mathf.Clamp(value, -moveSpeed/2, moveSpeed); }
        get { return _currentMoveSpeed;  }
    }
    public float handeling;
    public float drifting;
    public float acceleration;
    public float health;
    private float _gas;
    [SerializeField]
    public float Gas
    {
        set { _gas = Mathf.Clamp(value, 0, gasTank); }
        get { return _gas; }
    }
    public float gasTank;


    public ParticleSystem particleSystem;
    public ParticleSystem[] driftParticleSystem;
    public ModelContainer[] bodies;
    public Renderer body;
    public Rigidbody rb;
    public GameObject driver;
    public CameraMovement cam;
    public GameObject vCam;
    public ParticleSystem explosion;

    public float moveSpeedMin;
    public float moveSpeedMax;
    public float handelingMin;
    public float handelingMax;
    public float driftingMin;
    public float driftingMax;
    public float accelerationMin;
    public float accelerationMax;
    public int healthMin;
    public int healthMax;
    public float gasTankMin;
    public float gasTankMax;

    private float currentVelocity;

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
        health = Random.Range(healthMin, healthMax);
        gasTank = Random.Range(gasTankMin, gasTankMax);
        Gas = Random.Range(gasTankMin, gasTankMax);

        int thisModel = Random.Range(0, 3);
        for (int i = 0; i < bodies.Length; i++)
        {
            if (i == thisModel)
            {
                body = bodies[i].thisModel;
                bodies[i].gameObject.SetActive(true);
            }
            else
            {
                bodies[i].gameObject.SetActive(false);
            }
        }
        //transform.localScale = new Vector3(Random.Range(1f, 2f), Random.Range(1f, 2f), Random.Range(1f, 2f));
    }
    
    
    public void takeFireDamage(float dps, bool onFire)
    {
        fire.SetActive(onFire);
        if (onFire)
        {
            health -= dps * Time.deltaTime;
        }
    }
    void Simulate()
    {
            onFire = (health<healthMax/9 && !hasExploded);
            takeFireDamage(17, onFire);
        

        particleSystem.emissionRate = Mathf.Pow(CurrentMoveSpeed, 2);
        //this is what actually moves the vehicle
        rb.velocity = transform.forward * CurrentMoveSpeed;
        rb.angularVelocity = new Vector3(0, 0, 0);
        if (!driving)
        {
            LoseMomentum();
            rb.mass = 600;
        }
        else
        {
            rb.mass = 60;
        }

        if (vCam != null)
        {
            //vCam.transform.eulerAngles = new Vector3(vCam.transform.eulerAngles.x, transform.eulerAngles.y, vCam.transform.eulerAngles.z);   
        }
        
        if (health <= 0 && !hasExploded)
        {
            explosion.Play();
            hasExploded = true;
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
        patrolling = false;
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
        if (Gas > 0)
        {
            CurrentMoveSpeed += verticalInput * Time.fixedDeltaTime * acceleration;
            Gas -= (CurrentMoveSpeed * Time.deltaTime) * 0.01f;
        }
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
            //cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(18, 13, 20), cam.offset.z);
            cam.offset = new Vector3(cam.offset.x, Mathf.Lerp(18, 10, 20), Mathf.Lerp(-18, 0, 20));
            particleSystem.emissionRate = 0;
            cam.targetAngle = 0;
        }
    }

    public GameObject[] patrolPoints;
    public GameObject currentPatrolPoints;
    public int currentPatrolPointIndex;

    private float currentAngle = 0;
    public float targetAngle = 0;
    private float angularVelocity;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            if (currentPatrolPointIndex>=patrolPoints.Length-1)
            {
                currentPatrolPointIndex = 0;
            }
            else
            {
                currentPatrolPointIndex++;
            }
            currentPatrolPoints = patrolPoints[currentPatrolPointIndex];
        }
    }

    void Patrol()
    {
        CurrentMoveSpeed = 14;
        transform.LookAt(currentPatrolPoints.transform, Vector3.up);
        rb.velocity = transform.forward * CurrentMoveSpeed;
        //currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref angularVelocity, 0.2f);
        //transform.localEulerAngles = new Vector3(currentAngle,0, 0);
    }
    void FixedUpdate()
    {
        if (driving)
        {
            Drive();
        }
        else if (patrolling)
        {
            Patrol();
        }
        Simulate();
    }

}
