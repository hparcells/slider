using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour {
    public Text deathText;
    public AudioSource selectSound;

    private bool shouldDoAction = true;

    void Start () {
        deathText.text = "Deaths: " + PlayerController.deaths;
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
