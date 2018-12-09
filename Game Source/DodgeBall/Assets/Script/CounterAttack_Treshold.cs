using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAttack_Treshold : MonoBehaviour {

    public static GameObject collidedCT;
    private GameObject mPlayer;

    private void Start()
    {
        mPlayer = GameObject.Find("Player");
    }

    private void Update()
    {
        this.transform.position = new Vector2(mPlayer.transform.position.x, this.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.GetComponent<BulletBehavior>().type == 0)
        {
            collidedCT = collision.gameObject;
            Debug.Log("Bullet in");
        }
    }
}
