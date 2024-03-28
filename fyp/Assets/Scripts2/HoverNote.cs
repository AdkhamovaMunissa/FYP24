using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class HoverNote : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI noteText;
    public Image background;

    public string hintNote;

    void Start()
    {
        noteText.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        noteText.text = hintNote;
        noteText.gameObject.SetActive(true);
         background.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        noteText.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }
}
