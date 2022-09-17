using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    public float zoom = 5f;
    public float normal = 13.6293f;
    public float smooth = 5;

    public bool isZoomed = false;

    public bool characterLocked;

    public float timeToSwitch = 2f;
    private float timePassed = 0f;

    public PlayerSwitcher playerSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetMouseButtonDown(1))
        {
            ChangeZoom();
        }
        
        if (isZoomed)
        {
            timePassed += Time.deltaTime;
            
            if(Input.GetKeyDown(KeyCode.Space) || PlayerSwitcher.uIPressed)
            {
                characterLocked = false;
                timePassed = 0f;
            }
            
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoom, Time.deltaTime * smooth);

            if(timePassed < timeToSwitch)
            {
                transform.position = Vector3.Lerp(transform.position, playerSwitcher.players[playerSwitcher.getPlayerIndex()].transform.position + new Vector3(0, 1, -10), timePassed/timeToSwitch);
            }
            else{
                transform.position = playerSwitcher.players[playerSwitcher.getPlayerIndex()].transform.position + new Vector3(0, 1, -10);
            }
            
        }
        else if(!isZoomed)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, normal, Time.deltaTime * smooth);
            transform.position = Vector3.Lerp(transform.position, new Vector3(4.56f, 3.4f, -10), Time.deltaTime * smooth);
            timePassed = 0f;
        }


    }

    public void ChangeZoom()
    {
        isZoomed = !isZoomed;
    }
}
