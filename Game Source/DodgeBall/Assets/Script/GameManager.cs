using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Declare Game Attribute
    private static GameManager gameManager;
    private float healthPoint;
    private int score;
    private bool gameOver = false;
    private bool gameStart = false;

    [HideInInspector]
    public static List<GameObject> listEnemies = new List<GameObject>();
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    private float lastSpawnTime;
    private int currentEnemiesSpawn = 0;
    private int enemiesSpawned = 0;
    private static int index = 0;
    int currentWave;
    //End of Declare Game Attribute

    // Declare Game Object
    public Player mPlayer;
    // End of Declare Game Object

    private void Awake()
    {
        gameManager = this.gameObject.GetComponent<GameManager>();
    }

    // Get Instance of Game Manager
    public static GameManager GetInstanceOfGameManager()
    {
        return gameManager;
    }

    // Use this for initialization
    void Start()
    {
        mPlayer = GameObject.Find("Player").GetComponent<Player>();
        HealthPoint = 100;
        Score = 0;
        initSpawnEnemies();
    }

    //Spawn Enemies
    void initSpawnEnemies()
    {
        lastSpawnTime = Time.time;
        currentWave = 0;
        waves[currentWave].updateMaxEnemies();
        gameStart = true;
        Debug.Log("Game Start: " + gameStart);
    }

    void spawnEnemies()
    {
        if (currentWave < waves.Length)
        {
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].interval;
            if (enemiesSpawned != waves[currentWave].maxEnemies)
            {
                if (index < waves[currentWave].enemyNums.Length)
                {
                    if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) || 
                        timeInterval > spawnInterval) && enemiesSpawned < waves[currentWave].maxEnemies && 
                        currentEnemiesSpawn < waves[currentWave].enemyNums[index]){
                        lastSpawnTime = Time.time;
                        //waves[currentWave].enemiesPrefab.GetComponent<EnemiesPrefabs>().setCurrentType(waves[currentWave].types[index]);
                        GameObject newEnemy = (GameObject)Instantiate(waves[currentWave].enemiesPrefab, waves[currentWave].position[index], Quaternion.identity);
                        newEnemy.GetComponent<EnemiesPrefabs>().setCurrentType(waves[currentWave].types[index]);
                        listEnemies.Add(newEnemy);
                        enemiesSpawned++;
                        currentEnemiesSpawn++;
                    }
                    else if (currentEnemiesSpawn == waves[currentWave].enemyNums[index])
                    {
                        currentEnemiesSpawn = 0;
                        index++;
                    }
                }
            }
            if (enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                enemiesSpawned = 0;
                currentEnemiesSpawn = 0;
                index = 0;
                currentWave++;
                lastSpawnTime = Time.time;
                waves[currentWave].updateMaxEnemies();
            }
        }else{
            gameOver = true;
        }
    }
    //End of Spawn Enemies

    // Counter Attack Mechanic
    public void CounterAttack_Engage()
    {
        if (CounterAttack_Treshold.collidedCT != null)
        {
            Debug.Log("Counter Enggage");
            CounterAttack_Treshold.collidedCT.GetComponent<BulletBehavior>().CounterAttack();
        }
    }
    // End of Counter Attack Mechanic

    // Update is called once per frame
    void Update () {
        if (gameStart)
        {
            spawnEnemies();
        }
            

	}

    //Setter-Getter
    public float HealthPoint
    {
        get { return healthPoint; }
        set { healthPoint = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    //End of Setter-Getter
}
[System.Serializable]
public class Wave
{
    public Vector3[] position;
    public GameObject enemiesPrefab;
    public int[] types;
    public int[] enemyNums;
    public float interval;
    [HideInInspector]
    public int maxEnemies;
    public void updateMaxEnemies()
    {
        for (int i = 0; i < this.enemyNums.Length; i++)
        {
            maxEnemies += this.enemyNums[i];
        }
    }
}