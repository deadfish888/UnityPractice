namespace BanGa
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public static class Prefs
    {
        public static int bestScore
        {
            get => PlayerPrefs.GetInt(GameConsts.BEST_SCORE, 0);
            set
            {
                int curBestScore = PlayerPrefs.GetInt(GameConsts.BEST_SCORE);

                if (value > curBestScore)
                {
                    PlayerPrefs.SetInt(GameConsts.BEST_SCORE, value);
                }
            }
        }
    }
}