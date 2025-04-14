using UnityEngine;

public class StickySurface : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null && collision.collider.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static; // freeze in place
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null && collision.collider.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // restore movement
        }
    }
}