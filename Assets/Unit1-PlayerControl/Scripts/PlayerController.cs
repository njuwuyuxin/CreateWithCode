using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxVelocity=20f;
    public float MaxTurnVelocity=5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * MaxVelocity * Time.deltaTime*forwardInput);
        transform.Rotate(Vector3.up * MaxTurnVelocity * Time.deltaTime*horizontalInput*forwardInput);
    }
}
