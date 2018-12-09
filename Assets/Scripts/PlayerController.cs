using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D playerRb2d;
    public float playerMoveSpeed;
    public AudioSource portalSound;
    public AudioSource deathSound;
    public AudioSource jumpSound;
    public AudioSource keySound;

    public static int currentLevel = 1;
    public static int deaths = 0;

    private float move;
    private bool canMove;
    private bool hasKey = false;
    private bool shouldDeath = false;

    void Start () {
        playerRb2d = GetComponent<Rigidbody2D>();
        canMove = true;
        playerRb2d.isKinematic = false;
        shouldDeath = true;
    }

    private void Update() {
        playerRb2d.transform.rotation = Quaternion.identity;
    }

    void FixedUpdate() {
        if(canMove) {
            move = Input.GetAxis("Horizontal");
            playerRb2d.velocity = new Vector2(move * playerMoveSpeed, playerRb2d.velocity.y);
        }

        // Force reset.
        if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)) {
            deathSound.Play();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Collider2D collider = collision.collider;

        // Portal collision.
        if(collision.gameObject.tag == "Portal") {
            portalSound.Play();
            freeze();

            if(Application.CanStreamedLevelBeLoaded("Level" + ++currentLevel)) {
                Initiate.Fade("Level" + currentLevel, Color.white, 5);
            } else {
                currentLevel = 1;
                Initiate.Fade("Ending", Color.white, 5);
            }

            shouldDeath = false;
        }

        // Locked Portal collision.
        if(collision.gameObject.name == "Locked Portal" && hasKey) {
            portalSound.Play();
            freeze();

            if(Application.CanStreamedLevelBeLoaded("Level" + ++currentLevel)) {
                Initiate.Fade("Level" + currentLevel, Color.white, 5);
            } else {
                currentLevel = 1;
                Initiate.Fade("Ending", Color.white, 5);
            }

            shouldDeath = false;
        }

        // Key collision
        if(collision.gameObject.name == "Key") {
            collision.collider.enabled = false;
            collision.gameObject.transform.parent = gameObject.transform;
            keySound.Play();
            hasKey = true;
        }

        // Jump block action.
        if(collision.gameObject.tag == "Jump Block") {
            jumpSound.Play();
            playerRb2d.velocity = new Vector2(playerRb2d.velocity.y, 10);
        }

        // Death from enemy.
        if(collision.gameObject.tag == "Enemy") {
            deathSound.Play();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        if(shouldDeath) {
            Debug.Log("Deaths: " + ++deaths);
            deathSound.Play();
            resetLevel();
        }
    }

    private void resetLevel() {
        Initiate.Fade(SceneManager.GetActiveScene().name, Color.red, 5);
    }

    private void freeze() {
        canMove = false;
        playerRb2d.isKinematic = true;
        playerRb2d.velocity = new Vector2(0, 0);
    }
}
