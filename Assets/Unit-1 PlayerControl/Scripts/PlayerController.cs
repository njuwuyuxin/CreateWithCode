using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horsePower=20000f;
    [SerializeField] float maxTurnVelocity=40f;
    private float speed;
    private float rpm;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        speedometerText.text = "Speed: " + speed + " mph";
        rpm = Mathf.Round((speed % 30) * 40);
        rpmText.text = "Rpm: " + rpm;
    }

    void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //transform.Translate(Vector3.forward * maxTurnVelocity * Time.deltaTime*forwardInput);
            transform.Rotate(Vector3.up * maxTurnVelocity * Time.deltaTime * horizontalInput);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
