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
        SoundController.Instance.StopAudio(SoundType.Lose);
        SoundController.Instance.StopAudio(SoundType.Win);
    }

    public void OnClickRetryButton()
    {
        PopupController.Instance.HideAll();
        GameController.Instance.ReplayLevel();
        PopupController.Instance.Show<GamePopup>();
        SoundController.Instance.StopAudio(SoundType.Lose);
        SoundController.Instance.StopAudio(SoundType.Win);
    }
    public void OnClickNextLevelButton()
    {
        PopupController.Instance.HideAll();
        GameController.Instance.NextLevel();
        PopupController.Instance.Show<GamePopup>();
        SoundController.Instance.StopAudio(SoundType.Lose);
        SoundController.Instance.StopAudio(SoundType.Win);
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

            string s = "";
            for (int i = 0; i < ConfigController.Level.LevelCount(); i++)
            {
                if (i == Data.IndexLevel)
                {
                    s += "-" + score.ToString();
                }
                else
                {
                    s += "-" + ConfigController.Level.MaxScoreLevel(i);
                }
            }
            s = s.Remove(0, 1);
            Data.SetString(Constant.LEVEL_DATA, s);


        }
        else
        {
            NewRecordImage.SetActive(false);
        }

        Debug.Log(Data.LevelData + " ; " + ConfigController.Level.LevelCount());
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
        Debug.Log(Data.LevelData + " ; " + ConfigController.Level.LevelCount());
    }
}
