using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInverter : MonoBehaviour
{
    public float rotationValue = 90;
    public List <GameObject> players = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D()
    {
        foreach (GameObject g in players)
        {
            g.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            g.GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }
}
