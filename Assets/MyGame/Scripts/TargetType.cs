using UnityEngine;

[System.Serializable]
public class TargetType
{
    public string name;
    public int points;
    public Color color;

    public TargetType(string name, int points, Color color)
    {
        this.name = name;
        this.points = points;
        this.color = color;
    }
}
