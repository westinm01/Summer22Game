using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public bool isCollecting = false;

    float upSpeed;
    public float bounceLimit = 600;

    public bool isButtonPressed = false;
    public float buttonDirection = 1f;
    public bool jumpButtonPressed = false;
    
    public Animator playerAnimator;
    public int height = 1;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        float dirX = Input.GetAxisRaw("Horizontal");
        if(isButtonPressed)
        {
            dirX = buttonDirection;
        }
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);
        bool movingLR = dirX != 0;
        playerAnimator.SetBool("isWalking", movingLR);
        if (movingLR)
        {
            GetComponent<SpriteRenderer>().flipX = dirX > 0;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || jumpButtonPressed) && IsGrounded())
        {
            jumpButtonPressed = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            
        }
        if (gc.isGrounded)
        {
            upSpeed = 0f;
            print("Grounded");
            
        }
        playerAnimator.SetBool("isGrounded", IsGrounded());
        
       
    }

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.name == "Goal") {
            wh.incrementPlayers();
        }
        else if (col.gameObject.tag == "Collectible"){
            //col.GetComponent<AudioSource>().Play();
            //TODO: Make coin audio play. Can't be audio source on collectable.
            wh.incrementCollectibles();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "HeavyButton")
        {
            HeavyButton hb = col.gameObject.GetComponent<HeavyButton>();
            if(hb.requiredHeight <= this.height)
            {
                Debug.Log(this.height);
                hb.actions.Invoke();
                hb.Disappear();
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.name == "Goal") {
            wh.decrementPlayers();
        }
    }
    //for reverse gravity, need to check opposite direction?
    private bool IsGrounded(){
        float extraHeightTest = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center , boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightTest, platformLayerMask | playerLayerMask);
        return raycastHit.collider !=null;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Tramp" && gc.isGrounded == false)
        {
            upSpeed += 100f;

            if (upSpeed >= bounceLimit)
            {
                upSpeed = bounceLimit;
            }

            rb.AddForce(new Vector2(0, upSpeed));
        }
        else

        {

            if (col.gameObject.tag == "tramp" == false)

            {

                upSpeed = 0f;

            }

        }
    }
    public void ButtonMoveEvent(bool isButtonPressed, float direction)
    {
        this.isButtonPressed = isButtonPressed;
        this.buttonDirection = direction;
    }

    public void SetJumpButtonPressed(bool newVal)
    {
        if(this.enabled)
        {
            jumpButtonPressed = newVal;
        }
        
    }

}
