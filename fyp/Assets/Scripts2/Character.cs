using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Character : MonoBehaviour
{

    [SerializeField] float runSpeed = 10f;
    
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;


    public Transform targetPosition;

    private bool gameStarted = false;
    
    void Start()
    {
        
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        // transform.position = targetPosition.position;
        // myAnimator.SetBool("isMoving", true);
        // transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, runSpeed * Time.deltaTime);
        // myAnimator.SetBool("isMoving", false);
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
