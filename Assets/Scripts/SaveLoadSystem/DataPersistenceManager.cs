using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    public FileDataHandler dataHandler;
    private string selectedProfileId = "";
    public static DataPersistenceManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
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
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }
    public void ChangeSelectedProfileId(string newProfileId)
    {
        this.selectedProfileId = newProfileId;
        LoadGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
        gameData.playerPosition = new Vector3(144.5f, 11f, -168f);
        gameData.minimapPosition = new Vector3(144.5f, 11f, -168f);

        gameData.LidiaPosition = new Vector3(142.346f, 9.963f, -75.21175f);
        gameData.LidiaRotation = new Vector3(0f, -186.071f, 0f);

        gameData.KrisPosition = new Vector3(23.25331f, 4.003f, 24.31875f);
        gameData.KrisRotation = new Vector3(0f, -246.529f, 0f);

        gameData.RobertPosition = new Vector3(27.37f, 0.08999991f, 22.38f);
        gameData.RobertRotation = new Vector3(0f, -55.954f, 0f);

        gameData.JessPosition = new Vector3(53.96458f, 0.09300017f, -92.90377f);
        gameData.JessRotation = new Vector3(0f, 76.078f, 0f);

        gameData.StevePosition = new Vector3(55.15535f, 0.1129999f, -92.98103f);
        gameData.SteveRotation = new Vector3(0f, 62.995f, 0f);

        gameData.ggHP = 80;
    }
    public void LoadGame()
    {
        this.gameData = dataHandler.Load(selectedProfileId);
        if (this.gameData == null)
        {
            return;
        }
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

    }
    public void SaveGame()
    {

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
        dataHandler.Save(gameData, selectedProfileId);
    }
    private void OnApplicationQuit()
    {
        //SaveGame();
    }
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
    public bool HasGameData()
    {
        return gameData != null;
    }
    public Dictionary<string, GameData> GetAllProfiesGameData()
    {
        return dataHandler.LoadAllProfiles();
    }
}
