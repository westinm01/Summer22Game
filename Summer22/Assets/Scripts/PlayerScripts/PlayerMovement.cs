using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private LayerMask platformLayerMask;

    [SerializeField]
    private LayerMask playerLayerMask;
    
    [SerializeField]
    private float movementSpeed = 3.5f;
    [SerializeField]
    private float jumpPower = 3.5f;

    public GroundCheck gc;
    public Rigidbody2D rb;
    public winHandle wh;
    public BoxCollider2D boxCollider2D;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Goal") {
            wh.currentPlayers++;
            if(wh.currentPlayers == wh.playersNeeded)
            {
                wh.handleWin();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name == "Goal") {
            wh.currentPlayers--;
        }
    }

    private bool IsGrounded(){
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center , boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightTest, platformLayerMask | playerLayerMask);
        return raycastHit.collider !=null;
    }
}
