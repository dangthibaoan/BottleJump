using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Level1 : Level
{
    //public BottleController bottle;
    private int score;
    private bool isEnd = false;
    private float scaleValue = 1.5f;
    public Transform scaletranform;

    private void Awake()
    {
        score = 0;
        PopupController.Instance.GetPopup<GamePopup>().setCurrentScore(score);
        scaletranform.transform.DOScale(scaleValue, .01f);
    }

    public void onClickBack()
    {
        SceneController.Instance.LoadHomeScene();
    }

    public void endLevel()
    {
        if (isEnd == false)
        {
            isEnd = true;
            Debug.Log("enddddddd");
            PopupController.Instance.GetPopup<WinPopup>().SetTotalScore(score);
            PopupController.Instance.Hide<GamePopup>();
            PopupController.Instance.Show<WinPopup>();
        }
    }
}
