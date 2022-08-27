using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInverter : MonoBehaviour
{
    public float rotationValue = 180;
    public List <GameObject> players = new List<GameObject>();
    private bool top = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        foreach (GameObject g in players)
        {
            //g.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            g.GetComponent<Rigidbody2D>().gravityScale *= -1;
            if (top)
            {
                g.transform.eulerAngles = new Vector3(0, 0, 180f);
            }
            else
            {
                g.transform.eulerAngles = Vector3.zero;
            }
            
        }
        top = !top;
    }
}
