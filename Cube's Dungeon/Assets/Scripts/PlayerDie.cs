using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathMenuUI;       // Assign your UI death menu panel here
    public GameObject playerVisual;      // Assign the visual part of the player (e.g., sprite)

    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("DeathPlatform"))
        {
            HandleDeath();
        }
    }

    void HandleDeath()
    {
        isDead = true;

        // Hide the player visual (they "disappear")
        if (playerVisual != null)
            playerVisual.SetActive(false);

        // Disable movement & physics
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;

        // Show death UI
        if (deathMenuUI != null)
            deathMenuUI.SetActive(true);

        // Pause game
        Time.timeScale = 0f;
    }
}