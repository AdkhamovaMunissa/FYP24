using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CheckDrop : MonoBehaviour, IDropHandler
{
    public GameObject correctObject; // The correct object to be dropped on the slot
    public bool OnDropSuccess = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // Check if the correct object is dropped on the slot
            if (eventData.pointerDrag.gameObject == correctObject)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                OnDropSuccess = true;
                Debug.Log("Drop Successfull");
            }
            else{
                OnDropSuccess = false;
                Debug.Log("Drop Fail");
            }
            
        }
    }

}
