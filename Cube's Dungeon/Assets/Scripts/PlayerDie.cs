using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathMenuUI; 
    public GameObject playerVisual;

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

        if (playerVisual != null)
            playerVisual.SetActive(false);

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Collider2D>().enabled = false;

        if (deathMenuUI != null)
            deathMenuUI.SetActive(true);

        Time.timeScale = 0f;
    }
}