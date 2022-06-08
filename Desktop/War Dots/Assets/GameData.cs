using System;
[System.Serializable]
public class GameData
{
	public int BiggestUnlockedLevel;

	public GameData(int BiggestUnlockedLevel_int)
    {
        BiggestUnlockedLevel = BiggestUnlockedLevel_int;
    }
}
