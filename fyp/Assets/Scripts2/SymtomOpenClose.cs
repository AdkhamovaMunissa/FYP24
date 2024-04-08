using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymtomOpenClose : MonoBehaviour
{
    public GameObject PanelDialog;

    public void OpenClosePanel()
    {
        if (PanelDialog != null)
        {   
            // if active, will return true. If inactive, return false
            Debug.Log("OpenCloseBtnActive");
            bool isActive = PanelDialog.activeSelf;
            PanelDialog.SetActive(!isActive);

        }
    }
}
