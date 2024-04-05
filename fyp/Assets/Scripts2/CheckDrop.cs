using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CheckDrop : MonoBehaviour, IDropHandler
{
    public GameObject correctObject; // The correct object to be dropped on the slot
    public bool OnDropSuccess = false;
    public TextMeshProUGUI WarningText;


    private void Start()
    {
        WarningText.gameObject.SetActive(false);
        WarningText.transform.parent.gameObject.SetActive(false);

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag == correctObject)
            {
               eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("Correct object");
                OnDropSuccess = true;

                WarningText.gameObject.SetActive(true);
                WarningText.transform.parent.gameObject.SetActive(true);
                WarningText.text = "Excellent. It is correct!";

                eventData.pointerDrag = null;
                return; 
            }
            else 
            {
                Debug.Log("Not the correct object");

                WarningText.gameObject.SetActive(true);
                WarningText.transform.parent.gameObject.SetActive(true);
                WarningText.text = "Oops! Wrong equipment...";
            }
             
        }
        
    }

}
