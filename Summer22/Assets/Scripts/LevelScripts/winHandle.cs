using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class winHandle : MonoBehaviour
{
    public int playersNeeded=0;
    public int collectiblesNeeded = 1;
    public int currentPlayers=0;
    public int currentCollectibles = 0;

    public CollectDisplay collectDisplay;

    public PauseManager pauseManager;

    void Start(){
        //count how many collectibles are in the scene.
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
            handleWin();
        }
    }
}
