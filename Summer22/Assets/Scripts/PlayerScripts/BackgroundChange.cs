using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public float duration = 3.0f;
    
    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        cam.backgroundColor = Color.Lerp(Color.red, Color.blue, t);
        
    }
}
