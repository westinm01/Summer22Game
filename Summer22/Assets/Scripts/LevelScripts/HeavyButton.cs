using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeavyButton : MonoBehaviour
{
    //public List<Action> actionList = new List<Action>();
    public UnityEvent actions;
    public float requiredHeight;
    private bool isPressed = false;
    public float timerToFall = 1f;
    private float timer=0;
    private GameObject p;//parent

    private bool pressCheck = true;// checks if this is the first frame after the button pressed.
    private AudioSource pressSound;

    void Start(){
        p = transform.parent.gameObject;
        pressSound = GetComponent<AudioSource>();
    }
/* Wasn't working... Moved functionality to PlayerMovement
    void onCollisionEnter2D(Collider2D col){
        Debug.Log("Hit");
        if(col.gameObject.layer == 7 || col.gameObject.layer == 8)
        {
            //if(col.gameObject.transform.localScale.y >= requiredHeight)
            //{
                /*for (int i = 0; i < actionList.Count; i++)
                {
                    actionList[i]();
                }
                actions.Invoke();
                Debug.Log("Correct Hit");
            //}
        }
        Destroy(this.gameObject);
    }
    */

    void Update(){
        if(isPressed)
        {
            if(pressCheck)
            {
                pressSound.Play();
            }
            pressCheck=false;
            timer+= Time.deltaTime;
            if(timer>=timerToFall)
            {
                timer=0;
                Destroy(p);
                Destroy(this);
            }
        }
    }
    public void Disappear(){
        if(!isPressed)
        {
        p.AddComponent<Rigidbody2D>();
        p.GetComponent<BoxCollider2D>().enabled=false;
        isPressed = true;
        }
    }
}
