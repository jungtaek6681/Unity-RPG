using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public int value;

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
        File.WriteAllText(path, value.ToString());
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
            string text = File.ReadAllText(path);
            value = int.Parse(text);
        }
    }

    private void Create()
    {
        value = 0;
        Save();
    }
}
