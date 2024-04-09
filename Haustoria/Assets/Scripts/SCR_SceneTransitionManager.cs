using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_SceneTransitionManager : MonoBehaviour//, IDataPersistance
{

    private Animator anim;

    public int SceneLoad;

    [SerializeField] private Vector3 BriarLoadPosition;

  

  


    public void SetDestinationX(int x)
    {
        BriarLoadPosition.x = x;
    }
    public void SetDestinationY(int y)
    {
        BriarLoadPosition.y = y;
    }
    public void SetDestinationZ(int z)
    {
        BriarLoadPosition.z = z;
       
    }

    public void ForceSavePosition()
    {
        DataPersistanceManager.instance.gameData.BriarPosition = BriarLoadPosition;
        Debug.Log(BriarLoadPosition);
    }

/*    public void SaveData(GameData data)
    {

        data.BriarPosition = BriarLoadPosition;

    }

    public void LoadData(GameData data)
    {

    }*/

    public void SetScene(int scene)
    {
        SceneLoad = scene;
        DataPersistanceManager.instance.gameData.SceneId = scene;
    }

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
