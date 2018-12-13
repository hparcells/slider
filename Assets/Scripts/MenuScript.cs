using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {
    public AudioSource selectSound;
    public Text version;

    private bool shouldDoAction = true;

    void Start() {
        Debug.Log("Hello World!");
        Debug.Log("Playing On Version: " + Constants.version);
        Debug.Log("Current Fastest Time: " + Util.formatSeconds(PlayerPrefs.GetFloat("bestTime")));

        version.text = "v" + Constants.version;
    }

    void FixedUpdate () {
        if(shouldDoAction) {
            if(Input.GetKey(KeyCode.RightArrow)) {
                selectSound.Play();
                Initiate.Fade("Level1", Color.white, 2);
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
