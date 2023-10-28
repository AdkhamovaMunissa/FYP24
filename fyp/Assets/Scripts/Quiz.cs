using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerBtns;
    int correctAnsIndex;
    [SerializeField] Sprite defaultAnsSprite;
    //default anssprite color: #09FFA0 
    [SerializeField] Sprite correctAnsSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerBtns.Length; i++)
        {
            TextMeshProUGUI buttonText = answerBtns[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

    }

    public void OnAnswerSelected(int index)
    {
        Image btnImage;

        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            btnImage = answerBtns[index].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
            btnImage.color = Color.white;
            
        }
        else
        {
            correctAnsIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnsIndex);
            questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
            btnImage = answerBtns[correctAnsIndex].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
            btnImage.color = Color.white;
            
        }
    }


}
