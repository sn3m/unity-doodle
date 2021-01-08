using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public float sidewaysForce;
    public float maxSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * sidewaysForce;
        float vertical = Input.GetAxisRaw("Vertical") * sidewaysForce/6;
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Limit max speed
        Vector2 velocityXZ = new Vector2(rb.velocity.x, rb.velocity.z);
        if (velocityXZ.magnitude > maxSpeed)
        {
            move.x *= (maxSpeed / velocityXZ.magnitude);
            move.z *= (maxSpeed / velocityXZ.magnitude);
        }

        // Add force
        rb.AddForce(-move.x * Time.deltaTime, 0, move.y * Time.deltaTime);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
