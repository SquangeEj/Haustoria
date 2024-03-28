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
        SceneManager.LoadScene(2);
    }

    public void ContinueGame()
    {
        DataPersistanceManager.instance.LoadGame();

        anim.Play("FadeIn");

        SceneManager.LoadScene(DataPersistanceManager.instance.gameData.SceneId);
     
    }

    private void StartEvent()
    {
    
       
    }
    public void Quit()
    {
        Application.Quit();
    }
}

