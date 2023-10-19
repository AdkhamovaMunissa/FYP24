using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public Canvas introScene;
    public Canvas round2Scene;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Round2Scene()
    {
        SceneManager.LoadScene("Round2-detrimental");  
    }

    public void Round1Scene()
    {
        SceneManager.LoadScene("Round1-objectives");  
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

    
}
