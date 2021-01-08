using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement movement;
    public GameObject textPrefab;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
            Vector3 normal = collision.GetContact(0).normal;
            if (normal.y > 0)
            {
                SoundManager.PlaySound("jump");
                movement.Jump();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            // Disable coin collider and renderer
            other.GetComponent<CapsuleCollider>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;
            // Add Score
            var addScore = other.GetComponent<CoinManager>().coinScore;
            gameManager.Score += addScore;
            // Display floating text
            GameObject floatingText = Instantiate(textPrefab, other.transform.position, Quaternion.identity);
            floatingText.GetComponent<TextMesh>().text = "+" + addScore.ToString("0");
            // Play sound
            SoundManager.PlaySound("coin");
        }
    }
}
