using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowAns = 10f;

    public bool loadNextQuestion;
    public float fillFraction;

    public bool isAnsweringQuestion;
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    public void ResetTimer()
    {
        timerValue = timeToCompleteQuestion;
        isAnsweringQuestion = true;
    }

    void UpdateTimer()
    {
        // timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            timerValue -= Time.deltaTime;
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                //timerValue = timeToShowAns;
            }
        }
        else
        {
            // if(timerValue > 0)
            // {
            //     fillFraction = timerValue / timeToShowAns;
            // }
            // else
            // {
            //     isAnsweringQuestion = true;
            //     timerValue = timeToCompleteQuestion;
            //     loadNextQuestion = true;
            // }
        }
    }

}
