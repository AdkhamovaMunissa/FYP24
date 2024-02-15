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

    public void Stage1_rounds()
    {
        SceneManager.LoadScene("Stage1_rounds");
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

    public void MG_intro_1()
    {
        SceneManager.LoadScene("MG_intro_1");  
    }    

    public void MiniGame_1()
    {
        SceneManager.LoadScene("MiniGame_1");  
    }  

    public void MG_Congr_1()
    {
        SceneManager.LoadScene("MG_Congr_1");  
    } 

    public void Round1_2()
    {
        SceneManager.LoadScene("Round1.2-regulatory");  
    }

    public void MG_intro_2()
    {
        SceneManager.LoadScene("MG_intro_2");  
    }    

    public void MiniGame_2()
    {
        SceneManager.LoadScene("MiniGame_2");  
    }  

    public void MG_Congr_2()
    {
        SceneManager.LoadScene("MG_Congr_2"); 
    }

    public void Round1_3()
    {
        SceneManager.LoadScene("Round1.3-regulatory");  
    }

    public void MG_intro_3()
    {
        SceneManager.LoadScene("MG_intro_3");  
    }    

    public void MiniGame_3()
    {
        SceneManager.LoadScene("MiniGame_3");  
    }  

    public void MG_Congr_3()
    {
        SceneManager.LoadScene("MG_Congr_3"); 
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

    public void MG2_intro_1()
    {
        SceneManager.LoadScene("MG2_intro_1");  
    }    

    public void MiniGame2_1()
    {
        SceneManager.LoadScene("MiniGame2_1");  
    }  

    public void MG2_Congr_1()
    {
        SceneManager.LoadScene("MG2_Congr_1"); 
    }

    public void Round2_2()
    {
        SceneManager.LoadScene("Round2_2");
    }

    public void MG2_intro_2()
    {
        SceneManager.LoadScene("MG2_intro_2");  
    }    

    public void MiniGame2_2()
    {
        SceneManager.LoadScene("MiniGame2_2");  
    }  

    public void MG2_Congr_2()
    {
        SceneManager.LoadScene("MG2_Congr_2"); 
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

    public void Round1_gameIntro()
    {
        SceneManager.LoadScene("Round1_gameIntro");
    }

    public void Stage2quiz()
    {
        SceneManager.LoadScene("Stage2quiz");
    }
    
}
