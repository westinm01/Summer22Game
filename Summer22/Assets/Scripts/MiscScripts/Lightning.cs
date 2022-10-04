using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float frequency1;
    public float frequency2;

    private float timePassed = 0f;
    private float currentFrequency;

    public Camera cam;

    private bool hasStruck = false;
    public float fadeTime = 2.0f;
    private float fadeTimePassed = 0f;

    [SerializeField]
    private AudioSource thunder;

    // Start is called before the first frame update
    void Start()
    {
        thunder = GetComponent<AudioSource>();
        currentFrequency = Random.Range(frequency1, frequency2);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= currentFrequency)
        {
            //do action;
            cam.backgroundColor = Color.white;
            timePassed = 0f;
            currentFrequency = Random.Range(frequency1, frequency2);
            hasStruck = true;
            thunder.Play();
        }
        if(hasStruck)
        {
            fadeTimePassed += Time.deltaTime;
            if(fadeTimePassed <= fadeTime)
            {
                cam.backgroundColor = Color.Lerp(Color.white, Color.black, fadeTimePassed/fadeTime);
            }
            else{
                hasStruck = false;
                fadeTimePassed = 0f;
            }
        }
    }
}
