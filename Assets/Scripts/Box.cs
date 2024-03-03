using UnityEngine;

public class Box : MonoBehaviour, ISaveLoadable
{
    public void GetItem(PlayerInteractor playerInteractor)
    {
        Debug.Log($"Interact with {playerInteractor.name} and Get item");
    }

    public void Break()
    {
        Destroy(gameObject);
    }

    public void SaveData(GameData gameData)
    {
        gameData.gameScene.boxPos = transform.position;
    }

    public void LoadData(GameData gameData)
    {
        transform.position = gameData.gameScene.boxPos;
    }
}
