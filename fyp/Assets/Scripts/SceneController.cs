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

    public void Round2ObjectivesScene()
    {
        SceneManager.LoadScene("Round2-objectives");
    }
}
