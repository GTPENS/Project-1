using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("X: " + transform.position.x);
        // Keyboard Input
        if (Input.GetKey("d"))
            transform.Translate(0.1f, 0, 0);
        if (Input.GetKey("a"))
            transform.Translate(-0.1f, 0, 0);
        // End of Keyboard Input
        
        // Accelerometer Input
        transform.Translate(Input.acceleration.x, 0, 0);
        // End of Accelerometer Input
        
        // Border of Movement
        if (transform.position.x >= Screen.width / 100)
            transform.position = new Vector2(Screen.width / 100 - 0.1f, transform.position.y);
        if (transform.position.x <= -Screen.width / 100)
            transform.position = new Vector2(-Screen.width / 100 + 0.1f, transform.position.y);
        // End of Border of Movement
    }
}
