using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float movementSpeed = 3.5f;
    [SerializeField]
    private float jumpPower = 3.5f;

    public Rigidbody2D rb;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left*movementSpeed, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right*movementSpeed, ForceMode2D.Impulse);
        }*/
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
