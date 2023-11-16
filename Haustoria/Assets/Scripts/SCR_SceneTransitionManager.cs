using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_SceneTransitionManager : MonoBehaviour
{

    private Animator anim;

    public int SceneLoad;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("EnterScene");
    }



    public void swapscene()
    {
        anim.Play("ExitScene");
    }

    private void sceneload()
    {
        SceneManager.LoadScene(SceneLoad);
    }


}
