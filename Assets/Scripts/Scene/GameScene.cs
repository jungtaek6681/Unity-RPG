using System.Collections;
using UnityEngine;

public class GameScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void Title()
    {
        Manager.Scene.LoadScene("TitleScene");
    }
}
