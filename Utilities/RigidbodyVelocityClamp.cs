using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyVelocityClamp : MonoBehaviour
{
    public float maxSpeed = 100.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}
