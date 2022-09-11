using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winHandle : MonoBehaviour
{
    public int playersNeeded = 0;
    public int collectiblesNeeded = 1;
    public int currentPlayers = 0;
    public int currentCollectibles = 0;


    public CollectDisplay collectDisplay;

    public PauseManager pauseManager;

    

    public int currentScene;

    public int keepTrackOfLevel;


    void Start(){
        //count how many collectibles are in the scene.
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex;
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        keepTrackOfLevel = currentScene;

         PlayerPrefs.GetInt("levelAt", currentScene + 1);
         PlayerPrefs.GetInt("max", keepTrackOfLevel);
    }
    
    public void handleWin()
    {
        //SceneManager.LoadScene("Main Menu"); //instead, should go to win screen!
        pauseManager.Pause(1); //pause game and load up win screen
    }

    public void incrementPlayers(){
        currentPlayers++;
        checkWin();
    }

    public void decrementPlayers(){
        currentPlayers--;
    }

    public void incrementCollectibles(){
        currentCollectibles++;
        collectDisplay.reduceCollectibles();
        checkWin();
    }

    private void checkWin(){
        if(currentPlayers == playersNeeded && currentCollectibles == collectiblesNeeded)
        {

            Debug.Log(keepTrackOfLevel);

            if(keepTrackOfLevel < currentScene)
            {
                currentScene = keepTrackOfLevel - 1;
                print(":" + currentScene);
            }
            else
            {
                if (PlayerPrefs.GetInt("leveAt") > PlayerPrefs.GetInt("max"))
                {
                    PlayerPrefs.SetInt("max", keepTrackOfLevel);

                }

                if (SceneManager.GetActiveScene().buildIndex == 9)
                {
                    Debug.Log("You reached the end of this world");
                }
                else
                {
                    if (keepTrackOfLevel > PlayerPrefs.GetInt("leveAt"))
                    {

                        PlayerPrefs.SetInt("levelAt", PlayerPrefs.GetInt("max"));

                    }


                }
            }
          
           


            handleWin();

            

            
        }
    }
}
