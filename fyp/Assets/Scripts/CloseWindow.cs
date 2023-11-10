using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour
{
    [SerializeField] GameObject windowToClose;
    [SerializeField] GameObject windowToShow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetWindow()
    {
        gameObject.SetActive(false);
       
    }
}
