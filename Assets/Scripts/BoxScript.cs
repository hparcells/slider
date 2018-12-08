using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {
    public Rigidbody2D cubeRb2d;
    public AudioSource jumpSound;

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Portal action.
        if(collision.collider.name == "Portal") {
            Destroy(gameObject);
        }

        // Jump block action.
        if(collision.gameObject.tag == "Jump Block") {
            jumpSound.Play();
            cubeRb2d.velocity = new Vector2(cubeRb2d.velocity.x, 10);
        }
    }
}
