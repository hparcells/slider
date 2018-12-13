using System;
using UnityEngine;

public class Util : MonoBehaviour {
    public static string formatSeconds(float seconds) {
        TimeSpan time = TimeSpan.FromSeconds(seconds);

        string totalMinutes = time.Minutes.ToString();
        string totalSeconds = time.Seconds.ToString();
        string totalMiliseconds = time.Milliseconds.ToString();

        // TODO: Fix this bad code.

        if(totalMinutes == "0" ||
        totalMinutes == "1" ||
        totalMinutes == "2" ||
        totalMinutes == "3" ||
        totalMinutes == "4" ||
        totalMinutes == "5" ||
        totalMinutes == "6" ||
        totalMinutes == "7" ||
        totalMinutes == "8" ||
        totalMinutes == "9") {
            totalMinutes = "0" + totalMinutes;
        }

        if(totalSeconds == "0" ||
        totalSeconds == "1" ||
        totalSeconds == "2" ||
        totalSeconds == "3" ||
        totalSeconds == "4" ||
        totalSeconds == "5" ||
        totalSeconds == "6" ||
        totalSeconds == "7" ||
        totalSeconds == "8" ||
        totalSeconds == "9") {
            totalSeconds = "0" + totalSeconds;
        }

        if(totalMiliseconds == "0" ||
        totalMiliseconds == "1" ||
        totalMiliseconds == "2" ||
        totalMiliseconds == "3" ||
        totalMiliseconds == "4" ||
        totalMiliseconds == "5" ||
        totalMiliseconds == "6" ||
        totalMiliseconds == "7" ||
        totalMiliseconds == "8" ||
        totalMiliseconds == "9") {
            totalMiliseconds = "00" + totalMiliseconds;
        }

        return totalMinutes + ":" + totalSeconds + "." + totalMiliseconds;
    }
}
