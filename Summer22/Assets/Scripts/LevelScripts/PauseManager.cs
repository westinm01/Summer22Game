using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public List<GameObject> screens = new List<GameObject>();
    private List<bool> isPaused = new List<bool>();
    private bool gameIsPaused;

    void Start()
    {
        gameIsPaused = false;
        for (int i = 0; i < screens.Count; i++)
        {
            isPaused.Add(false);
        }
    }

    public void Pause(int val)
    {
        if (!gameIsPaused)
        {
            isPaused[val] = true;
            screens[val].SetActive(true);
            gameIsPaused = true;
            Time.timeScale = 0;
        }
        else if (gameIsPaused && isPaused[val])
        {
            isPaused[val] = false;
            screens[val].SetActive(false);
            gameIsPaused = false;
            Time.timeScale = 1;
        }
    }
}
