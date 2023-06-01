using UnityEngine;

public class BounceOnCollision : MonoBehaviour
{
    [SerializeField] private float _bounceFactor = 0.8f;
    [SerializeField] private LayerMask _wallLayer;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // This method is called whenever this object starts colliding with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object it's colliding with is in the specified layer
        if (((1 << collision.gameObject.layer) & _wallLayer) != 0)
        {
            // The normal of the collision is a vector that points directly away from the collision surface
            Vector3 normal = collision.contacts[0].normal;
            // The velocity of the rigidbody before the collision
            Vector3 incomingVector = _rb.velocity;
            // Reflect the incoming vector off the collision normal, this gives the direction the ball should travel post-collision
            Vector3 reflectedVector = Vector3.Reflect(incomingVector, normal);

            // Apply the change in velocity (with bounce factor) to the ball
            _rb.velocity = reflectedVector * _bounceFactor;
        }
    }
}
