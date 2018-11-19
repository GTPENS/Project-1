using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Declare Game Object
    private GameManager gameManager;
    // End of Declare Game Object

    // Declare UI Component
    public Text dodgeText;
    public Text scoreText;
    // End of Declare UI Component

	// Use this for initialization
	void Start () {
        gameManager = GameManager.GetInstanceOfGameManager();
	}
	
	// Update is called once per frame
	void Update () {
        dodgeText.text = "Dodge: " + gameManager.mPlayer.curDodge;
        scoreText.text = "Score: " + gameManager.Score;
	}
}
