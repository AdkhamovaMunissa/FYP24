using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject animatedObject;
    bool buttonPressed = false;
    Animator myAnimator;
    void Start()
    {
        myAnimator = animatedObject.GetComponent<Animator>();
        myAnimator.SetBool("isHolding", buttonPressed); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed)
        {
            Debug.Log("ButtonPressed");
            
        }

        if(myAnimator != null)
        {
            myAnimator.SetBool("isHolding", buttonPressed); 
        }
       
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        
    }
}
