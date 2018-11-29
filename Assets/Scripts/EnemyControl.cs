using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public Rigidbody2D enemyRb2d;
    public AudioSource jumpSound;

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
        if(collision.gameObject.tag == "Jump Block") {jumpSound.Play();
            jumpSound.Play();
            enemyRb2d.velocity = new Vector2(enemyRb2d.velocity.y, 10);
        }

        // Go away.
        if(collision.gameObject.name == "Portal") {
            Destroy(gameObject);
        }
    }

    // Destory when off screen.
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
