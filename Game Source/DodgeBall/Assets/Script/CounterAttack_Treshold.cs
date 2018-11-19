using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack_Treshold : MonoBehaviour {

    public static GameObject collidedCT;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.GetComponent<BulletBehavior>().type == 0)
        {
            collidedCT = collision.gameObject;
            Debug.Log("Bullet in");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.GetComponent<BulletBehavior>().type == 0)
        {
            collidedCT = other.gameObject;
            Debug.Log("Bullet in");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        collidedCT = null;
    }
}
