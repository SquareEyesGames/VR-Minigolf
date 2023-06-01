using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private string _targetTag = "ball";

    // moves the ball to the next hole when it enters the trigger collider inside the hole
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_targetTag))
        {
            _gameManager.GoToNextHole();
        }
    }
}
