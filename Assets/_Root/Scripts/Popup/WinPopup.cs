using UnityEngine;
using TMPro;

public class WinPopup : Popup
{
    public TextMeshProUGUI NewScore;
    public TextMeshProUGUI BestScore;
    public GameObject NewRecordImage;
    public GameObject CongratsImage;
    public GameObject NextLevelButton;
    public GameObject RetryButton;
    public void OnClickHomeButton()
    {
        PopupController.Instance.HideAll();
        SceneController.Instance.LoadGameScene();
    }

    public void OnClickRetryButton()
    {
        PopupController.Instance.HideAll();
        GameController.Instance.ReplayLevel();
        PopupController.Instance.Show<GamePopup>();
    }
    public void OnClickNextLevelButton()
    {
        PopupController.Instance.HideAll();
        GameController.Instance.NextLevel();
        PopupController.Instance.Show<GamePopup>();
    }

    public void SetTotalScore(int score)
    {
        SoundController.Instance.PlayOnce(SoundType.Win);

        RetryButton.SetActive(false);

        if (Data.IndexLevel < ConfigController.Level.LevelCount() - 1)
            NextLevelButton.SetActive(true);
        else
            NextLevelButton.SetActive(false);

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
        RetryButton.SetActive(true);
        NextLevelButton.SetActive(false);
        SoundController.Instance.PlayOnce(SoundType.Lose);
        CongratsImage.SetActive(false);
        NewRecordImage.SetActive(false);
        NewScore.SetText(score + "");
        BestScore.SetText(Data.MaxScore + "");
    }
}
