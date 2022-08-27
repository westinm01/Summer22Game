using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded=false;


    void onTriggerEnter2D(Collision2D col){
        Debug.Log("Collision detected");
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void onCollisionEnter2D(Collision2D col){
        Debug.Log("Collision detected");
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void onCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            isGrounded = false;
        }
    }
    
}
