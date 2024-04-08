using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    public GameObject objectToRotate;
    public TextMeshProUGUI WarningText;
    public float rotationAmount = 10f;
    public bool placedCorrectly = false;
    

    private void Start()
    {
        WarningText.gameObject.SetActive(false);
        WarningText.transform.parent.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (objectToRotate != null)
        {
            float rotationZ = objectToRotate.transform.eulerAngles.z;
            rotationZ = (rotationZ + 360f) % 360f;

            if (rotationZ >= 30f && rotationZ < 40f)
            {
                Debug.Log("Z rotation is equal to 30");
                placedCorrectly = true;

                WarningText.gameObject.SetActive(true);
                WarningText.transform.parent.gameObject.SetActive(true);
                WarningText.text = "Excellent. It is correct!";
            }
            else
            {
                WarningText.gameObject.SetActive(true);
                WarningText.transform.parent.gameObject.SetActive(true);
                WarningText.text = "Try rotating more";
            }
        }
        else
        {
            Debug.LogError("Object to rotate not assigned!");
        }
    }
    public void RotateLeft()
    {
        RotateObjectByAmount(rotationAmount);
    }

    public void RotateRight()
    {
        RotateObjectByAmount(-rotationAmount);
    }

    private void RotateObjectByAmount(float amount)
    {
        if (objectToRotate != null)
        {
            objectToRotate.transform.Rotate(0f, 0f, amount);
        }
        else
        {
            Debug.LogError("Object to rotate not assigned!");
        }
    }
}
