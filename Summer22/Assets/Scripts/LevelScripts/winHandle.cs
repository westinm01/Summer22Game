using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class winHandle : MonoBehaviour
{
    public int playersNeeded = 0;
    public int collectiblesNeeded = 1;
    public int currentPlayers = 0;
    public int currentCollectibles = 0;

    


    public CollectDisplay collectDisplay;

    public PauseManager pauseManager;

    

   // public int currentScene;

   // public int keepTrackOfLevel;

    public int nextSceneload;


    void Start(){
        //count how many collectibles are in the scene.
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        int max = PlayerPrefs.GetInt("max", 0);
        nextSceneload = SceneManager.GetActiveScene().buildIndex + 1;
        
       // currentScene = SceneManager.GetActiveScene().buildIndex;
       // nextSceneLoad = currentScene;

     //    PlayerPrefs.GetInt("levelAt", currentScene + 1);
      //   PlayerPrefs.GetInt("max", nextSceneLoad);
    }
    
    public void handleWin()
    {
        //SceneManager.LoadScene(""); //instead, should go to win screen!
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

            // Debug.Log(nextSceneLoad);

           

            if (SceneManager.GetActiveScene().buildIndex == 22)
                {
                    Debug.Log("You reached the end of this world");
                }
                else
                {
                Debug.Log("Current levelAt Value: " + PlayerPrefs.GetInt("levelAt"));

                Debug.Log("Current Max Value: " + PlayerPrefs.GetInt("max"));

                Debug.Log("Current nextSceneLoad Value: " + nextSceneload);

                if (nextSceneload >= PlayerPrefs.GetInt("levelAt"))
                    {

                    Debug.Log(PlayerPrefs.GetInt("levelAt"));

                    PlayerPrefs.SetInt("levelAt", nextSceneload);
                    //nextSceneload++;

                    Debug.Log(PlayerPrefs.GetInt("levelAt"));

                    //**********************************************************

                    

                    Debug.Log(PlayerPrefs.GetInt("max"));

                    if (PlayerPrefs.GetInt("levelAt") > PlayerPrefs.GetInt("max"))

                    { 
                        PlayerPrefs.SetInt("max", PlayerPrefs.GetInt("levelAt")); 
                    }

                    Debug.Log(PlayerPrefs.GetInt("max"));

                   

                }

            }
        
            handleWin();
 
        }
    }
}
