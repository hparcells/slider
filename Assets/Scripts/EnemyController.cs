﻿using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Rigidbody2D enemyRb2d;
    public AudioSource jumpSound;
    public AudioSource keySound;

    private bool hasKey = false;

    private int move = -1;

    private void Start() {
        enemyRb2d = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        enemyRb2d.transform.rotation = Quaternion.identity;
    }

    void FixedUpdate () {
        enemyRb2d.velocity = new Vector2(move * 3, enemyRb2d.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Bounce off of wall.
        if(collision.gameObject.tag == "Enemy Bounce") {
            move = -move;
        }

        // Jump block action.
        if(collision.gameObject.tag == "Jump Block") {
            jumpSound.Play();
            enemyRb2d.velocity = new Vector2(enemyRb2d.velocity.y, 10);
        }

        // Go away.
        if(collision.gameObject.name == "Portal") {
            Destroy(gameObject);
        }

        // Key collision
        if(collision.gameObject.name == "Key") {
            collision.collider.enabled = false;
            collision.gameObject.transform.parent = gameObject.transform;
            keySound.Play();
            hasKey = true;
        }
    }

    // Destory when off screen.
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
