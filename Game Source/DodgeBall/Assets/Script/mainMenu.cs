using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

    public GameObject settingPanel;
    public GameObject shopPanel;
    public GameObject creditPanel;
    public GameObject helpPanel;
    public AudioSource mainBGM;
    public AudioSource clickSFX;
    // Use this for initialization
    void Start()
    {
        settingPanel.gameObject.SetActive(false);
        shopPanel.gameObject.SetActive(false);
        creditPanel.gameObject.SetActive(false);
        helpPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



    }

    // Setting

    public void onSettingButtonPressed()
    {
        clickSFX.Play();
        settingPanel.gameObject.SetActive(true);
    }

    public void onSettingApply()
    {
        clickSFX.Play();
        settingPanel.gameObject.SetActive(false);
    }

    public void musicToggle_Change(bool newValue)
    {

        if (newValue == false)
        {
            mainBGM.mute = true;
        }
        else if (newValue == true)
        {
            mainBGM.mute = false;
        }


    }


    // Shop

    public void shopPanelPressed()
    {
        clickSFX.Play();
        shopPanel.gameObject.SetActive(true);
    }

    public void shopBackButton()
    {
        clickSFX.Play();
        shopPanel.gameObject.SetActive(false);
    }

    // Credit
    public void creditPanelPressed()
    {
        clickSFX.Play();
        creditPanel.gameObject.SetActive(true);
    }

    public void creditBackButton()
    {
        clickSFX.Play();
        creditPanel.gameObject.SetActive(false);
    }



    // Help
    public void helpPanelButtonPressed() {
        clickSFX.Play();
        helpPanel.gameObject.SetActive(true);
    }

    public void helpPanelBackButtonPressed() {
        clickSFX.Play();
        helpPanel.gameObject.SetActive(false);
    }


    // Play

    public void onPlayButtonPRessed() {
        clickSFX.Play();
        SceneManager.LoadScene("Gameplay");
        // DO SOMETHING HERE PAK BOSKO
    }

}
