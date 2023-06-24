using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    private bool isEnd;
    private int score;

    private void Awake()
    {
        score = 0;
        isEnd = false;
        PopupController.Instance.GetPopup<GamePopup>().setCurrentScore(score);
    }

    public void endLevel(bool status)
    {
        if (isEnd == false)
        {
            isEnd = true;
            Debug.Log("enddddddd");
            PopupController.Instance.Hide<GamePopup>();
            if (status == true)
            {
                PopupController.Instance.GetPopup<WinPopup>().SetTotalScore(score);
            }
            else
            {
                PopupController.Instance.GetPopup<WinPopup>().Lose(score);
            }
            GameController.Instance.FinishGame();
        }
    }
    public void GetScore(int bonus)
    {
        score = score + bonus;
        PopupController.Instance.GetPopup<GamePopup>().setCurrentScore(score);
    }
    public void LoseScore(int lose)
    {
        score = score - lose < 0 ? 0 : score - lose;
        PopupController.Instance.GetPopup<GamePopup>().setCurrentScore(score);
    }
}
