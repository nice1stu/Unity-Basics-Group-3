using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float handeling;

    public Renderer body;

    public float moveSpeedLowerRange;
    public float moveSpeedUpperRange;
    public float handelingLowerRange;
    public float handelingUpperRange;

    private float verticalInput;
    private float horizontalInput;

    public bool driving;
    private void Start()
    {
        body.material.color = Color.HSVToRGB(Random.Range(0f, 1f), 0.7f, .8f);
        moveSpeed = Random.Range(moveSpeedLowerRange, moveSpeedUpperRange);
        handeling = Random.Range(handelingLowerRange, handelingUpperRange);
    }
    void drive()
    {
        if (horizontalInput > .1f)
        {
            transform.Rotate(0f, handeling * Time.deltaTime, 0f);
        }
        if (horizontalInput < -.1f)
        {
            transform.Rotate(0f, -handeling * Time.deltaTime, 0f);
        }
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, verticalInput * moveSpeed * Time.deltaTime);

    }
    void Update()
    {
        if (driving)
        {
            drive();
        }
    }

}
