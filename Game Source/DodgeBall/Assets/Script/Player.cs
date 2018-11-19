﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed = 0.1f;

    public int curDodge;
    public int maxDodge;
    private Queue<float> lastTimeDodge = new Queue<float>();
    private float intervalDodge = 3;
    // Use this for initialization
    void Start()
    {
        curDodge = 3;
        maxDodge = 3;
        Collider collider = gameObject.GetComponentInChildren<Collider>();
        // do whatever you want with the collider
        collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("X: " + transform.position.x);
        // Keyboard Input
        if (Input.GetKey("d"))
            transform.Translate(speed, 0, 0);
        if (Input.GetKey("a"))
            transform.Translate(-speed, 0, 0);
        // End of Keyboard Input

        // Accelerometer Input
        transform.Translate(Input.acceleration.x, 0, 0);
        // End of Accelerometer Input

        // Border of Movement
        if (transform.position.x >= Screen.width / 100 + 4.3f)
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
        if (transform.position.x <= -Screen.width / 100 - 4.3f)
            transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        // End of Border of Movement


        if (curDodge < maxDodge)
        {
            if (Time.time - lastTimeDodge.Peek() > intervalDodge){
                curDodge++;
                lastTimeDodge.Dequeue();
            }
        }
    }

    public void DodgeRight()
    {
        if (curDodge > 0)
        {
            lastTimeDodge.Enqueue(Time.time);
            transform.Translate(speed * 10, 0, 0);
            curDodge--;
        }
    }

    public void DodgeLeft()
    {
        if (curDodge > 0)
        {
            lastTimeDodge.Enqueue(Time.time);
            transform.Translate(-(speed * 10), 0, 0);
            curDodge--;
        }
    }

}
