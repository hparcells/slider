using System;
using UnityEngine;

public class Util : MonoBehaviour {
    public static string formatSeconds(float seconds) {
        TimeSpan time = TimeSpan.FromSeconds(seconds);

        int totalMinutes = time.Minutes;
        int totalSeconds = time.Seconds;
        int totalMiliseconds = time.Milliseconds;

        return totalMinutes.ToString("00") + ":" + totalSeconds.ToString("00") + "." + totalMiliseconds.ToString("000");
    }
}
