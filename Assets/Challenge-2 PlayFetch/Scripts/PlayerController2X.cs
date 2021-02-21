using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2X : MonoBehaviour
{
    public GameObject dogPrefab;
    public float CoolDown = 2f;
    private bool isCoolDown = true;
    private float timer=0;

    // Update is called once per frame
    void Update()
    {
        if (!isCoolDown)
        {
            timer += Time.deltaTime;
            if (timer >= CoolDown)
            {
                timer = 0;
                isCoolDown = true;
            }
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space)&&isCoolDown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            isCoolDown = false;
        }
    }
}
