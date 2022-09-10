using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public Button[] lvlButtons;
    
    

    public void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        int max = PlayerPrefs.GetInt("max", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
       
            Debug.Log(max);
            if (i + 3 > max)
                lvlButtons[i].interactable = false;
        }
        

    }
    
    



    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1.0f;
    }

    public void LoadLevelSelect()
    {
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
    }
}
