using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistanceManager : MonoBehaviour
{
    
    private GameData gameData;

    

    [Header("File storage config")]
    [SerializeField] private string fileName;


    private List<IDataPersistance> dataPersistenceObjects;

    private FileDataHandler dataHandler;

   public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("There is more than one data persistance manager");
            Destroy(this.gameObject);
            return;

        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load(); 

        if (this.gameData == null) // wont continue 
        {
            Debug.Log("No data was found");
            return;
            /*NewGame();*/
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistenceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }

        Debug.Log("Data was loaded");
    }

    public void SaveGame()
    {

        if(this.gameData == null)
        {
            Debug.LogWarning("No data was found, a new game needs to be created");
            return;
        }

        foreach (IDataPersistance dataPersistanceObj in dataPersistenceObjects)
        {
            dataPersistanceObj.SaveData(gameData);
        }

        dataHandler.Save(gameData);
        Debug.Log("Data was saved");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistance> dataPersitenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersitenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
