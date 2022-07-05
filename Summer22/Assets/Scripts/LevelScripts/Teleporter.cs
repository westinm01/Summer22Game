using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter otherTeleporter;
    private bool disableTeleport;
    private GameObject parentObject;
    // Start is called before the first frame update
    void Start()
    {
        disableTeleport = false;
        parentObject = otherTeleporter.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if(!disableTeleport)
        {
            otherTeleporter.disableTeleport = true;
            col.transform.position = new Vector3(parentObject.transform.position.x, parentObject.gameObject.transform.position.y+1, parentObject.gameObject.transform.position.z);
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        disableTeleport = false;
    }
}
