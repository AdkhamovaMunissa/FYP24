using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragFireExtinguisher : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public GameObject animatedObject;
    public GameObject fire;
    public GameObject limit;
    public GameObject initialPos;


    public TextMeshProUGUI warningText;
    GameObject parentWarning;
    float distanceLimit;
    bool buttonPressed = false;
    public float shrinkSpeed = 0.1f;
    Animator myAnimator;
    private Vector3 initialFireScale;
    private Vector3 initialFireOffset; 


    void Start()
    {
        myAnimator = animatedObject.GetComponent<Animator>();
        myAnimator.SetBool("isHolding", buttonPressed); 
        distanceLimit = Vector3.Distance(fire.transform.position, limit.transform.position);
        Debug.Log(distanceLimit);

        parentWarning = warningText.transform.parent.gameObject;
        warningText.enabled = false;
        parentWarning.SetActive(false);

        // Store the initial scale of the fire object
        initialFireScale = fire.transform.localScale;

        // Calculate the initial offset between the fire object and the initial position
        initialFireOffset = fire.transform.position - initialPos.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, fire.transform.position);
        

        if(distance <= distanceLimit)
        {
            Debug.Log("LIMIT!!! Distance between the two objects: " + distance); 
            warningText.enabled = true;
            parentWarning.SetActive(true);
            warningText.text = "Maintain a safe distance from the fire!";
        }
        else{
            warningText.enabled = false;
            parentWarning.SetActive(false);
        }

        if(myAnimator != null)
        {
            myAnimator.SetBool("isHolding", buttonPressed); 
        }
       
    }

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        buttonPressed = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        // Shrink the fire object gradually
        Vector3 newScale = fire.transform.localScale - Vector3.one * shrinkSpeed * Time.deltaTime;
        fire.transform.localScale = newScale;

        Debug.Log("Fire Scale: " + fire.transform.localScale);

        // Ensure the fire object doesn't shrink below a certain size (e.g., a minimum scale of 0.1)
        newScale = Vector3.Max(newScale, Vector3.one * 0.1f);
        fire.transform.localScale = newScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        buttonPressed = false;
        canvasGroup.blocksRaycasts = true;
        // Add any logic you want to perform when the drag ends
    }

}
