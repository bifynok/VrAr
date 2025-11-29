using System;

[Serializable]
public class LeaderboardEntry
{
    public int position;
    public string name;
    public int score;

    public override string ToString()
    {
        return $"Pos: {position}, Name: {name}, Score: {score}";
    }
}

[Serializable]
public class LeaderboardDataWrapper
{
    public LeaderboardEntry[] entries;
}
