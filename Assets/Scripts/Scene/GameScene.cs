using System.Collections;
using UnityEngine;

public class GameScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        // Fake loading
        Debug.Log("Resource load");
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("Player setup");
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("Monster spawn");
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("Scene prepare");
    }

    public void Title()
    {
        Manager.Scene.LoadScene("TitleScene");
    }
}
