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
            //player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyContraints.FreezeRotationZ;
        }
        players[0].GetComponent<PlayerMovement>().enabled=true;//enable the first one
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //disable current player
            players[playerIndex].GetComponent<PlayerMovement>().enabled = false;
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyContraints.FreezeRotationZ;
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
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }
}
