using UnityEngine;
using UnityEngine.UI;
public class GameController : Singleton<GameController>
{
    public Level LevelCurrent;

    protected override void Awake()
    {
        base.Awake();

        PopupController.Instance.Show<LevelPopup>();
    }

    private void Start()
    {
        //LoadLevel();
    }

    public void LoadLevel()
    {
        if (LevelCurrent != null)
        {
            Destroy(LevelCurrent.gameObject);
        }

        var level = ConfigController.Level.GetLevel(Data.IndexLevel);
        LevelCurrent = Instantiate(level, transform);
        Data.SetInt(Constant.MAX_SCORE, ConfigController.Level.MaxScoreLevel(Data.IndexLevel));
    }

    public void NextLevel()
    {
        Data.IndexLevel++;
        LoadLevel();
    }

    public void ReplayLevel()
    {
        LoadLevel();
    }

    public void FinishGame()
    {
        PopupController.Instance.Show<WinPopup>();
    }

}
