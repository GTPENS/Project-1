using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour {

    [SerializeField] int healthPoint;
    [SerializeField] float speed;
    [SerializeField] float interval;
    [SerializeField] float type;
    [SerializeField] GameObject bulletPrefab;
    private float lastShotTime;
    GameObject target;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        target = GameObject.Find("Player");
        if (Time.time - lastShotTime > interval)
        {
            Shoot(target.GetComponent<Collider2D>());
            lastShotTime = Time.time;
        }
        Vector3 direction = gameObject.transform.position - target.transform.position;
        gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
            new Vector3(0, 0, 1));
	}

    void Shoot (Collider2D target)  
    {
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
    }
}
