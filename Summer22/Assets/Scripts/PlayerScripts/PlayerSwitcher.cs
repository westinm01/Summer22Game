using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{

    public List<GameObject> players;
    private int playerIndex = 0;
    
    void Start()
    {
        foreach (GameObject player in players)
        {
            player.GetComponent<PlayerMovement>().enabled=false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            player.layer = LayerMask.NameToLayer("Player");
        }
        players[0].GetComponent<PlayerMovement>().enabled=true;//enable the first player
        players[0].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        players[0].layer = LayerMask.NameToLayer("Default");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //disable current player
            players[playerIndex].GetComponent<PlayerMovement>().enabled = false;
            players[playerIndex].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            players[playerIndex].layer = LayerMask.NameToLayer("Player");

            if (playerIndex == players.Count - 1)
            {
                playerIndex = 0;
            }
            else
            {
                playerIndex++;
            }
            //enable new player
            players[playerIndex].GetComponent<PlayerMovement>().enabled = true;
            players[playerIndex].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            
            players[playerIndex].layer = LayerMask.NameToLayer("Default");
        }
    }
}
