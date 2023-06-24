using UnityEngine;
using TMPro;

public class WinPopup : Popup
{
    public TextMeshProUGUI NewScore;
    public TextMeshProUGUI BestScore;
    public GameObject NewRecordImage;
    public GameObject CongratsImage;

    public void OnClickHomeButton()
    {
        // Data.SetInt(Constant.MAX_SCORE, 0);
        PopupController.Instance.HideAll();
        SceneController.Instance.LoadHomeScene();
    }

    public void OnClickRetryButton()
    {
        PopupController.Instance.HideAll();
        SceneController.Instance.LoadGameScene();
    }

    public void SetTotalScore(int score)
    {
        SoundController.Instance.PlayOnce(SoundType.Win);
        CongratsImage.SetActive(true);
        if (score > Data.MaxScore)
        {
            NewRecordImage.SetActive(true);
            Data.SetInt(Constant.MAX_SCORE, score);
        }
        else
        {
            NewRecordImage.SetActive(false);
        }
        NewScore.SetText(score + "");
        BestScore.SetText(Data.MaxScore + "");
    }
    public void Lose(int score)
    {
        SoundController.Instance.PlayOnce(SoundType.Lose);
        CongratsImage.SetActive(false);
        NewRecordImage.SetActive(false);
        NewScore.SetText(score + "");
        BestScore.SetText(Data.MaxScore + "");
    }
}
