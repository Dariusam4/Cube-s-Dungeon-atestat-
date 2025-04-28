using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public GameObject platformToDisable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (platformToDisable != null)
            {
                platformToDisable.SetActive(false);
            }
        }
    }
}