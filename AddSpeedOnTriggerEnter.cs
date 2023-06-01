using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private float _hitCooldown = 0.5f;
    [SerializeField] private BallSoundManager _ballSoundManager;

    private float _timeSinceLastHit;
    private Collider _clubCollider;
    private Vector3 _previousPosition;
    private Vector3 _velocity;

    void Start()
    {
        _previousPosition = transform.position;
        _clubCollider = GetComponent<Collider>();
    }

    void Update()
    {
        // Calculate the velocity of the club based on its position change over time
        _velocity = (transform.position - _previousPosition) / Time.deltaTime;
        _previousPosition = transform.position;

        // Update the time since the last hit
        _timeSinceLastHit += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the correct tag and if enough time has passed since the last hit
        if (other.CompareTag(_targetTag) && _timeSinceLastHit >= _hitCooldown)
        {
            // Calculate the closest point on the club's collider to the ball
            Vector3 collisionPosition = _clubCollider.ClosestPoint(other.transform.position);
            // Calculate the normal vector between the ball and the closest point on the club's collider
            Vector3 collisionNormal = (other.transform.position - collisionPosition).normalized;

            // Project the club's velocity onto the collision normal to get the velocity in the direction of the hit
            Vector3 projectedVelocity = Vector3.Project(_velocity, collisionNormal);

            // If the projected velocity is significantly different from zero, that means the club had a significant speed at the time of the collision, and thus the ball should move
            if (projectedVelocity.magnitude > 0.01f)
            {
                // Set the ball's velocity to the calculated projected velocity
                Rigidbody rb = other.attachedRigidbody;
                rb.velocity = projectedVelocity;

                _ballSoundManager.PlayPuttSound();

                // Increment the hit counter in the game manager
                _gameManager.currentHitNumber++;

                // Add all hits taken on all courts
                _gameManager.totalHitNumber++;
            }

            // Reset the time since the last hit
            _timeSinceLastHit = 0f;
        }
    }

    public Vector3 GetVelocity()
    {
        return _velocity;
    }
}
