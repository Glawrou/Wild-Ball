using System;
using System.Collections.Generic;

[Serializable]
public class PlayerProgressData
{
    public List<LevelResultData> levels;

    public void AddResult(int level, int stars)
    {
        if (levels.Count < level)
        {
            levels.Add(new LevelResultData(stars));
            return;
        }

        var oldStars = levels[level - 1].Stars;
        levels[level - 1].Stars = oldStars < stars ? stars : oldStars;
    }

    public PlayerProgressData()
    {
        levels = new List<LevelResultData>();
    }
}
