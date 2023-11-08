using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameWin : MonoBehaviour
{
    private int pointsToWin; // Total attainable win points here is 2
    private int currentPoints;
    public GameObject myAns;


    void Start()
    {
        pointsToWin = myAns.transform.childCount;
    }

    
    void Update()
    {
        if (currentPoints >= pointsToWin) // It is a win
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }


    public void AddPoints()
    {
        currentPoints++;
    }

}
