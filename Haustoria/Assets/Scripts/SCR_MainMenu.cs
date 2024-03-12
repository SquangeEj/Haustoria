using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_MainMenu : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartGame()
    {
        DataPersistanceManager.instance.NewGame();
     
        anim.Play("FadeIn");
    }

    private void StartEvent()
    {
    
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

