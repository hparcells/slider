using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
    public AudioSource selectSound;

	void Update () {
        if(Input.GetKey(KeyCode.RightArrow)) {
            Application.Quit();
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            selectSound.Play();
            Initiate.Fade("Level1", Color.white, 2);
        }
    }
}
