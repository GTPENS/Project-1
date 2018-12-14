using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    // Declare Game Object
    private GameManager gameManager;
    // End of Declare Game Object

    // Declare UI Component
    public Text dodgeText;
    public Text scoreText;
    public Text levelText;
    public GameObject panelPause;
    public GameObject panelGameOver;
    public Image healtBar;
    public Image gameOver;
    // End of Declare UI Component

    string placementId = "rewardedVideo";
#if UNITY_IOS
    private string gameId = "2964865";
#elif UNITY_ANDROID
    private string gameId = "2964864";
#endif

    // Use this for initialization
    void Start () {
        gameManager = GameManager.GetInstanceOfGameManager();
    }
	
	// Update is called once per frame
	void Update () {
        dodgeText.text = "Dodge: " + gameManager.mPlayer.curDodge;
       // scoreText.text = "Score: " + gameManager.Score;
        levelText.text = (gameManager.CurrentWave + 1).ToString();
        float ratio = gameManager.HealthPoint/100;
        healtBar.rectTransform.localScale = new Vector3(ratio, 1, 0);
        if (gameManager.gameOver)
        {
            popUpGameOver();
        }
	}

    public void popUpGameOver()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
    }

    public void Button_Continue_Click()
    {
        ShowAd();
    }

    public void Button_Resume_Click()
    {
        
        panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Button_Pause_Click()
    {
        Debug.Log("Test");
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Button_Home_Click()
    {
        SceneManager.UnloadScene("Gameplay");
        SceneManager.LoadScene("Main");
    }

    public void Button_Restart_Click()
    {
        SceneManager.UnloadScene("Gameplay");
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowAd()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video selesai-tawarkan coin ke pemain");
            gameManager.HealthPoint = 100;
            Time.timeScale = 1f;
            panelGameOver.SetActive(false);
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video dilewati-tidak menawarkan coin ke pemain");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video tidak ditampilkan");
        }
    }
}
