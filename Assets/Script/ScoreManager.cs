using UnityEngine;

public static class ScoreManager 
{
	public static int Score = 0;
	public static int BestScore = 0;
	public const string KEY = "BEST_SCORE_KEY";

	public static int IntializeBestScore()
	{
		BestScore = PlayerPrefs.HasKey(KEY) ? PlayerPrefs.GetInt(KEY) : Score;
		return BestScore;
	}

	public static void UpdateBestScore(int increment)
	{
		Score += increment;
		if (Score > BestScore)
		{
			BestScore = Score;
			PlayerPrefs.SetInt(KEY, BestScore);
		}
		Debug.Log($"Score: {Score}, BestScore: {BestScore}");
	}
}
