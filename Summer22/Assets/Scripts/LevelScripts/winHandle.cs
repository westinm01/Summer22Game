using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winHandle : MonoBehaviour
{
    public int playersNeeded=0;
    public int pointsNeeded=0;
    public int currentPlayers=0;
    
    public void handleWin()
    {
        SceneManager.LoadScene("Main Menu"); //instead, should go to win screen!
    }
}
