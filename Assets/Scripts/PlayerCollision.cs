using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement movement;
    public GameObject textPrefab;
    public Animator playerAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
            Vector3 normal = collision.GetContact(0).normal;
            if (normal.y > 0)
            {
                playerAnimator.SetTrigger("TriggerJumpAnim");
                SoundManager.PlaySound("jump");
                movement.Jump();
            }
        } else if(collision.collider.CompareTag("Bouncy"))
        {
            playerAnimator.SetTrigger("TriggerJumpAnim");
            SoundManager.PlaySound("bounce");
            movement.Jump(collision.collider.GetComponent<BouncyManager>().forceMultipyler);
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
