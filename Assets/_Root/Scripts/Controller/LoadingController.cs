using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadingController : Singleton<LoadingController>
{
    public Image LoadingBar;

    protected override void Awake()
    {
        base.Awake();
        LoadingBar.fillAmount = 0;
    }

    private void Start()
    {
        LoadingBar.DOFillAmount(1, 1).OnComplete(() =>
        {
            LoadLevelData();
            Data.SetBool(Constant.MUSIC_STATE, true);
            SceneController.Instance.LoadHomeScene();
        });
    }

    public void LoadLevelData()
    {
        string s = Data.GetString(Constant.LEVEL_DATA, "");
        if (string.IsNullOrEmpty(s))
        {
            for (int i = 0; i < ConfigController.Level.LevelCount(); i++)
            {
                s += "-0";
            }
            s = s.Remove(0, 1);
        }
        Data.SetString(Constant.LEVEL_DATA, s);
    }
}
