using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public Canvas introScene;
    public Canvas round2Scene;


    public void Stage1intro()
    {
        SceneManager.LoadScene("Stage1 intro");
    }

    public void Round1Scene()
    {
        SceneManager.LoadScene("Round1-objectives");  
    }

    public void Round1_0()
    {
        SceneManager.LoadScene("Round1-intro 2");  
    }

    public void Round1_1()
    {
        SceneManager.LoadScene("Round1.1-regulatory");  
    }

    public void Round1_2()
    {
        SceneManager.LoadScene("Round1.2-regulatory");  
    }

    public void Round1_3()
    {
        SceneManager.LoadScene("Round1.3-regulatory");  
    }

    public void Round1_4()
    {
        SceneManager.LoadScene("Round1.4-regulatory 2");  
    }

    public void Round2Scene()
    {
        SceneManager.LoadScene("Round2-detrimental");  
    }

    public void Round2ObjectivesScene()
    {
        SceneManager.LoadScene("Round2-objectives");
    }

    public void Round2_1()
    {
        SceneManager.LoadScene("Round2_1");
    }

    public void Round2_2()
    {
        SceneManager.LoadScene("Round2_2");
    }

    public void Round2_3()
    {
        SceneManager.LoadScene("Round2_3");
    }

    public void Round2_gameIntro()
    {
        SceneManager.LoadScene("Round2_gameIntro");
    }

    public void Stage1quiz()
    {
        SceneManager.LoadScene("Stage1quiz");
    }
    
}
