﻿using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public Rigidbody2D enemyRb2d;

    private float floatHeight = 16;

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
            enemyRb2d.velocity = new Vector2(enemyRb2d.velocity.y, 10);
        }
    }

    // Destory when off screen.
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}