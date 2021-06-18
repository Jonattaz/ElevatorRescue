using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   
   
    // Options Canvas
    public GameObject options;


    // Introduction Canvas
    public GameObject intro;

    // Menu Canvas
    public GameObject menu;

    // Cutscene
    public GameObject cutscene;

    // Menu And Options
    public GameObject menuOptions;

    // Credits 
    public GameObject credits;

    //Level 1
    public GameObject tutorial;

    //Cheat Controller
    public static bool cheat = false;


    // Load another scenes
    public void SceneLoad(int Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    // Allows the player to exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    
    // When the Options button is clicked, activate the options canvas and deactivate the menu canvas
    public void MenuToOptions()
    {
        menu.SetActive(false);
        options.SetActive(true);

    }


    // When the Menu button is clicked, activate the Menu canvas and deactivate the Options canvas
    public void OptionsToMenu()
    {
        options.SetActive(false);
        menu.SetActive(true);
    }

    public void MenuToIntroduction()
    {
        menu.SetActive(false);
        intro.SetActive(true);
    }

    public void IntroductionToCutscene() 
    {

        menuOptions.SetActive(false);
        cutscene.SetActive(true);
    
    }


    public void CutsceneToTutorial()
    {
        cutscene.SetActive(false);
        tutorial.SetActive(true);
    }

    public void MenuToCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void CreditsToMenu()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }


    public void CheatOn()
    {
        cheat = true;
    }

    public void CheatOff()
    {
        cheat = false;
        
    }


}











