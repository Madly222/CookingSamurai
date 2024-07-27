using UnityEngine;
public class Leveling: MonoBehaviour
{
    public int CurrentLevel { get; private set; }

    public void SetLevel(int level)
    {
        CurrentLevel = level;
    }
}
