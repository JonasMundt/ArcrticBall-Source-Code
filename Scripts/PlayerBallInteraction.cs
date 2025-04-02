using UnityEngine;

public class PlayerBallInteraction : MonoBehaviour
{
    public float hitForce = 5f; // Kraft, mit der der Ball geschlagen wird
    public AudioClip hitSound; // Sound für Ballkontakt
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Berechne die Kontaktposition relativ zum Spieler
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 playerCenter = transform.position;
            Vector2 hitDirection = new Vector2(contactPoint.x - playerCenter.x, 1f).normalized;

            ballRb.velocity = Vector2.zero; // Geschwindigkeit zurücksetzen
            ballRb.AddForce(hitDirection * hitForce, ForceMode2D.Impulse);

            
            PlaySound(hitSound); //Sound für Ballkontakt
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
