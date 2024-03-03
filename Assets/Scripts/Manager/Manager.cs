using UnityEngine;

public class Manager : MonoBehaviour
{
    private static Manager instance;
    public static Manager Inst { get { return instance; } }

    [SerializeField] SceneManager sceneManager;
    [SerializeField] DataManager dataManager;
    public static SceneManager Scene { get { return instance.sceneManager; } }
    public static DataManager Data { get { return instance.dataManager; } }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
        instance = FindObjectOfType<Manager>(true);
        if (instance == null)
        {
            Debug.LogError("Manager : Can't find singleton instance");
            return;
        }
        DontDestroyOnLoad(instance);

        Scene.Init();
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }
}
