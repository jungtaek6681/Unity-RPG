using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public GameData gameData;

    private void Start()
    {
        Load();
    }

    [ContextMenu("Save")]
    public void Save()
    {
#if UNITY_EDITOR
        string path = Path.Combine(Application.dataPath, "Data.txt");
#else
        string path = Path.Combine(Application.persistentDataPath, "data.text");
#endif
        string json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(path, json);
    }

    [ContextMenu("Load")]
    public void Load()
    {
#if UNITY_EDITOR
        string path = Path.Combine(Application.dataPath, "Data.txt");
#else
        string path = Path.Combine(Application.persistentDataPath, "data.text");
#endif
        if (File.Exists(path) == false)
        {
            Create();
        }
        else
        {
            string json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
    }

    private void Create()
    {
        gameData = new GameData();
        Save();
    }
}
