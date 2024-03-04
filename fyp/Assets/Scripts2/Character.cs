using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Character : MonoBehaviour
{

    // [SerializeField] float steerSpeed = 1f;
    // [SerializeField] float moveSpeed = 0.01f;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    //     float moveAmountx = Input.GetAxis("Horizontal") * moveSpeed;
    //     float moveAmounty = Input.GetAxis("Vertical") * moveSpeed;
    //     transform.Rotate(0, 0, 0);
    //     transform.Translate(0, moveAmounty, 0);
    //     transform.Translate(moveAmountx, 0, 0);

    // }

    [SerializeField] float runSpeed = 10f;
    
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    
    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
        Run();
        FlipCharacter();

        bool playerHasSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon || Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isMoving", playerHasSpeed);

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, moveInput.y * runSpeed);
        myRigidbody.velocity = playerVelocity;
    }

    void FlipCharacter()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x) *  Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }


}
