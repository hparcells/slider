using UnityEngine;

public class MenuScript : MonoBehaviour {
    public AudioSource selectSound;

    private bool shouldDoAction = true;

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
