using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPopup : Popup
{
    public void OnClickBackButton()
    {
        SoundController.Instance.PlayOnce(SoundType.ButtonClick);
        Hide();
        SceneController.Instance.LoadHomeScene();
    }

    public void OnClickLevel(int LevelIndex)
    {
        Hide();
        PopupController.Instance.Show<GamePopup>();
        Data.IndexLevel = LevelIndex;
        GameController.Instance.LoadLevel();
    }
}
