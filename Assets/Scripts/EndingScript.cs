using System;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour {
    public Text deathText;
    public Text timeText;
    public Text bestTime;
    public AudioSource selectSound;

    private bool shouldDoAction = true;

    void Start () {
        if(PlayerController.completionTime < PlayerPrefs.GetFloat("bestTime") || Constants.version != PlayerPrefs.GetString("version")) {
            PlayerPrefs.SetFloat("bestTime", PlayerController.completionTime);
            PlayerPrefs.SetString("version", Constants.version);
            PlayerPrefs.Save();
        }

        deathText.text = "Deaths: " + PlayerController.deaths;
        timeText.text = "Time: " + Util.formatSeconds(PlayerController.completionTime);
        bestTime.text = "Best Time: " + Util.formatSeconds(PlayerPrefs.GetFloat("bestTime"));

        PlayerController.completionTime = 0.0f;
	}

    void FixedUpdate() {
        if(shouldDoAction) {
            if(Input.GetKey(KeyCode.RightArrow)) {
                selectSound.Play();
                PlayerController.deaths = 0;
                Initiate.Fade("Menu", Color.white, 2);
                shouldDoAction = false;
            }

            if(Input.GetKey(KeyCode.LeftArrow) && !Application.isEditor) {
                selectSound.Play();
                Application.Quit();
                shouldDoAction = false;
            }
        }
    }
}
