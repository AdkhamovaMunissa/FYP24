using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkdialno : MonoBehaviour
{
    public TMP_InputField num;
    public TextMeshProUGUI output;

    public void Call()
    {
        if(num.text == "999")
        {
            output.text = "Calling 999....";
        }
        else
        {
            output.text = "Wrong choice. Try again!";
        }
    }
 
}
