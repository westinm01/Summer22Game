using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public Button[] lvlButtons;

    public Animator animator;

    public GameObject WorldOne;
    public GameObject WorldTwo;
    public GameObject WorldThree;

    public void Update()
    {

        //IF YOU WANT TO RESTART YOUR LEVEL PROGRESSION UNCOMMENT THIS AND PRESS R AT THE LEVEL SELECTION SCREEN AND ENTER A LEVEL AND COME BACK TO LEVEL SELECTION PROGRESS SHOULD BE RESET
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("max", 2);
            PlayerPrefs.SetInt("levelAt", 2);

        }
    }


    void Start()
    {
         for (int i = 0; i <= lvlButtons.Length; i++)
               {

                if(PlayerPrefs.GetInt("levelAt") > 8 && PlayerPrefs.GetInt("levelAt") <= 15)
                {
                WorldThree.SetActive(false);
                WorldOne.SetActive(false);
                WorldTwo.SetActive(true);
                }

                if(PlayerPrefs.GetInt("levelAt") > 15)
                {
                WorldOne.SetActive(false);
                WorldTwo.SetActive(false);
                WorldThree.SetActive(true);
                
                }
            Debug.Log("levelAt : " + PlayerPrefs.GetInt("levelAt"));
            Debug.Log("max : " + PlayerPrefs.GetInt("max"));
                        if (i + 2 <= PlayerPrefs.GetInt("max"))
                            lvlButtons[i].interactable = true;
               }

    }

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }

    public void LoadMainMenu()
    {
        //FadeToLevel(1);
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
    }

    public void LoadLevelSelect()
    {
       
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1.0f;
    }
    public void LoadLevelSelectWithFade()
    {
        FadeToLevel(1);
        SceneManager.LoadScene("LevelSelect");
        Time.timeScale = 1.0f;
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1.0f;
    }
}
