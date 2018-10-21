using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesBehavior : MonoBehaviour {
    private float lastShotTime;
    GameObject target;
    public GameObject bulletObject;
    BulletPrefabs bulletPrefab;
    EnemiesPrefabs enemiesPrefabs;
    float interval;

    // Use this for initialization
    void Start () {
        target = GameObject.Find("Player");
        enemiesPrefabs = gameObject.GetComponent<EnemiesPrefabs>();
        interval = enemiesPrefabs.CurrentType.fireRate;
        bulletPrefab = enemiesPrefabs.CurrentType.bullets;
        lastShotTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
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

        bulletObject.GetComponent<BulletPrefabs>().setCurrentType(bulletPercentage());
        GameObject newBullet = (GameObject)Instantiate(bulletObject);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
        bulletComp.circleCollider2D = newBullet.GetComponent<CircleCollider2D>();
        bulletComp.circleCollider2D.radius = bulletObject.GetComponent<BulletPrefabs>().CurrentType.radius;
    }

    int bulletPercentage()
    {
        List<float> mBulletA = enemiesPrefabs.CurrentType.bulletsPercentage.ToList<float>();
        mBulletA.Sort();
        int index = 0;
        float result = Random.Range(0.0F, 100.0F);
        for (int i = mBulletA.Count -1 ; i >= 0; i--)
        {
            if (result < mBulletA[i])
                index = i;
        }
        return index;
    }
}
