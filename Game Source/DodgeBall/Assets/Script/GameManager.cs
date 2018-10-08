using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Declare Game Attribute
    private int healthPoint;
    private int score;
    //End of Declare Game Attribute

    // Declare Game Object
    public GameObject mPlayer;
    public GameObject[] mEnemiesPrefab;
    // End of Declare Game Object

    //Setter-Getter
    public int HealthPoint
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

    //Spawn Enemies
    void spawnEnemies()
    {
        Instantiate(mEnemiesPrefab[0]);
    }
    //End of Spawn Enemies

	// Use this for initialization
	void Start () {
        HealthPoint = 3;
        Score = 0;
        spawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
