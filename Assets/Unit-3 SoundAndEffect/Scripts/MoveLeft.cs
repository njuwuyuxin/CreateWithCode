using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private PlayerController3 playerControllerScript;
    private float leftBound = -15f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScript.gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < leftBound&&gameObject.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
