using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float launchForce = 5f;

    public ScoreManager scoreManager; // Referenz zum ScoreManager
    private Vector2 initialPosition; // Startposition des Balls

    public AudioClip groundHitSound; // Bodensound
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        initialPosition = transform.position;
        LaunchBall();
    }

    void LaunchBall()
    {
        // Ball startet mit zufälliger Richtung
        Vector2 launchDirection = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        rb.velocity = Vector2.zero;
        rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (collision.gameObject.name == "LeftGround")
            {
                scoreManager.Player2Scores();
                PlaySound(groundHitSound);
                CheckGameEnd();
            }
            else if (collision.gameObject.name == "RightGround")
            {
                scoreManager.Player1Scores();
                PlaySound(groundHitSound);
                CheckGameEnd();
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    void CheckGameEnd()
    {
        if (scoreManager.ScorePlayer1 >= 5 || scoreManager.ScorePlayer2 >= 5)
        {
            rb.velocity = Vector2.zero;
            Debug.Log("Game Over!");
        }
        else
        {
            ResetBall();
        }
    }

    void ResetBall()
    {
        transform.position = initialPosition;
        LaunchBall();
    }
}
