using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    private BulletPrefabs bulletPrefabs;
    [HideInInspector]
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    [HideInInspector]
    public CircleCollider2D circleCollider2D;
    private float distance;
    private float startTime;
    private bool canCounter;
    private bool backFire = false;
    public bool canDamage;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public int type;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
        bulletPrefabs = gameObject.GetComponent<BulletPrefabs>();
        damage = bulletPrefabs.CurrentType.damage;
        type = bulletPrefabs.getCurretTypeIndex();
    }
	
	// Update is called once per frame
	void Update () {
       float timeInterval = Time.time - startTime;
        if (!backFire)
            gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * bulletPrefabs.CurrentType.speed / distance);
        else
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, startPosition, bulletPrefabs.CurrentType.speed / distance);
            if (gameObject.transform.position.y >= 1.5)
                Destroy(gameObject);
        }

        switch (type)
        {
                case 0:
                   canCounter = true;
                        break;
                case 1:
                    canCounter = false;
                    break;
        }        
        if (gameObject.transform.position.Equals(targetPosition))
        {
            Destroy(gameObject);
        }
    }

    public void CounterAttack()
    {
        if (canCounter)
        {
            distance = Vector3.Distance(gameObject.transform.position, startPosition);
            backFire = true;
            canDamage = true;
        }
    }
}
