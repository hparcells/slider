using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D playerRb2d;
    public float playerMoveSpeed;

    public static int currentLevel = 1;
    public static int deaths = 0;

    private float move;
    private bool canMove;

    void Start () {
        playerRb2d = GetComponent<Rigidbody2D>();
        canMove = true;
        playerRb2d.isKinematic = false;
    }

    private void Update() {
        playerRb2d.transform.rotation = Quaternion.identity;
    }

    void FixedUpdate() {
        if(canMove) {
            move = Input.GetAxis("Horizontal");
            playerRb2d.velocity = new Vector2(move * playerMoveSpeed, playerRb2d.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;

        // Portal collision.
        if(collision.gameObject.tag == "Portal") {
            freeze();

            if(Application.CanStreamedLevelBeLoaded("Level" + ++currentLevel)) {
                Initiate.Fade("Level" + currentLevel, Color.white, 5);
            }else {
                // TODO: Go to menu.
            }

            // TODO: Play sound.
        }

        // Jump block action.
        if(collision.gameObject.tag == "Jump Block") {
            playerRb2d.velocity = new Vector2(playerRb2d.velocity.y, 10);
        }

        // Death from enemy.
        if(collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        deaths++;
        resetLevel();
    }

    private void resetLevel() {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.red, 5);

        // TODO: Play sound.
    }

    private void freeze() {
        canMove = false;
        playerRb2d.isKinematic = true;
        playerRb2d.velocity = new Vector2(0, 0);
    }
}
