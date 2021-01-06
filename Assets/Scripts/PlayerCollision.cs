using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
            Vector3 normal = collision.GetContact(0).normal;
            if (normal.y > 0)
            {
                movement.Jump();
            }
        }
    }
}
