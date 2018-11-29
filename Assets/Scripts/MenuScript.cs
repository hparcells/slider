using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {
	void Update () {
        if(Input.GetKey(KeyCode.RightArrow)) {
            Application.Quit();
        }

        if(Input.GetKey(KeyCode.RightArrow)) {
            Initiate.Fade("Level1", Color.white, 2);
        }
    }
}
