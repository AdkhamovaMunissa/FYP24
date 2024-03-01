using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveAmountx = Input.GetAxis("Horizontal") * moveSpeed;
        float moveAmounty = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, 0);
        transform.Translate(0, moveAmounty, 0);
        transform.Translate(moveAmountx, 0, 0);

    }
}
