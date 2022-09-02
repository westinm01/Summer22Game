using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float zoom = 5f;
    public float normal = 13.6293f;
    public float smooth = 5;

    private bool isZoomed = false;

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
            isZoomed = !isZoomed;
        }
        
        if (isZoomed)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoom, Time.deltaTime * smooth);
            transform.position = playerSwitcher.players[playerSwitcher.getPlayerIndex()].transform.position + new Vector3(0, 1, -10);
        }
        else
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, normal, Time.deltaTime * smooth);
            transform.position = new Vector3(4.56f, 3.4f, -10);
        }


    }
}
