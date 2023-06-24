using UnityEngine;
using TMPro;

public class GamePopup : Popup
{
    public TextMeshProUGUI txt;
    public void OnClickBackButton()
    {
        SoundController.Instance.PlayOnce(SoundType.ButtonClick);
        Hide();
        SceneController.Instance.LoadHomeScene();
    }

    public void setCurrentScore(int score)
    {
        txt.SetText(score + "");
    }
}
