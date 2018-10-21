using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {
    private BulletPrefabs bulletPrefabs;
    [HideInInspector]
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public CircleCollider2D circleCollider2D;
    private float distance;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);
        bulletPrefabs = gameObject.GetComponent<BulletPrefabs>();
	}
	
	// Update is called once per frame
	void Update () {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * bulletPrefabs.CurrentType.speed / distance);

       
       if (gameObject.transform.position.Equals(targetPosition))
       {
            //  if (target != null)
            // {
            /*
            // 3
            Transform healthBarTransform = target.transform.Find("HealthBar");
            HealthBar healthBar =
                healthBarTransform.gameObject.GetComponent<HealthBar>();
            healthBar.currentHealth -= Mathf.Max(damage, 0);
            // 4
            if (healthBar.currentHealth <= 0)
            {
                Destroy(target);
                */
            //           }
            Debug.Log("Destory");
            Destroy(gameObject);
       }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Destory");
        }
    }
}
