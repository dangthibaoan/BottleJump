using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Game/LevelConfig", order = 0)]
public class LevelConfig : ScriptableObject
{
    public List<Level> Levels;

    public Level GetLevel(int index)
    {
        return Levels[index % Levels.Count];
    }
    public int LevelCount()
    {
        return Levels.Count;
    }
    public int MaxScoreLevel(int IndexLevel)
    {
        return int.Parse(Data.LevelData.Split("-")[IndexLevel].ToString());
    }
}