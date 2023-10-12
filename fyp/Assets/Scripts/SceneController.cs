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
        // introScene = GameObject.Find("Intro");
        // round2Scene = GameObject.Find("Round2");

        // SetObjectsActive(false, round2Scene);
        // SetObjectsActive(true, introScene);
        // introScene.enabled = true;
        // round2Scene.enabled = false;
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
}
