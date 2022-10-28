using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{

    public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be a black image or a loading graphic
    public float fadeSpeed = 0.8f;      //the fading speed

    private int drawDepth = -1000;     // the texture's order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f;       //the textures's alpha value between 0 and 1
    private int fadeDir = -1;          //the direction to fade: in = -1 or out =1

    void OnGUI()
    {
        //fade out/in the alpha value using a direction. a speed and Time.deltatime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force(clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);


        //set color of our GUI (in this case our texture ) . All color values remain the same and the alpha is set to the alpha variable 
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);        // set the alpha value
        GUI.depth = drawDepth;                                                      //make the black texture render on top (drawn last)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
   
    //sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); 
    }
   
    void OnLevelWasLoaded()
    {

        BeginFade(-1);
    }
}
