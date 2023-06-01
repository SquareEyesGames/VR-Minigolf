using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentHitNumber = 0;
    public int totalHitNumber = 0;
    public ActionBasedController controller;

    [SerializeField] private List<Transform> _startingPositions;
    [SerializeField] private Rigidbody _ballRigidbody;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTextColumn1;
    [SerializeField] private TMPro.TextMeshProUGUI _scoreTextColumn2;
    [SerializeField] private TMPro.TextMeshProUGUI _totalScore;
    [SerializeField] private TMPro.TextMeshProUGUI _totalScore2;
    [SerializeField] private InputActionProperty _resetBall;
    [SerializeField] private BallSoundManager _ballSoundManager;
    [SerializeField] private UIWindowManager _uiWindowManager;

    private int _currentHoleNumber = 0;
    private List<int> _previousHitNumbers = new List<int>();

    // Initialize ball position and score display
    void Start()
    {
        ResetBallPosition();
        _resetBall.action.performed += _ => ResetBallPosition();

        for (int i = 0; i < 18; i++)
        {
            _previousHitNumbers.Add(0);
        }

        _scoreTextColumn1.text = "";
        _scoreTextColumn2.text = "";
        UpdateScoreDisplay();
    }

    // moves the ball to the next hole aber going in the hole
    public void GoToNextHole()
    {
        _previousHitNumbers[_currentHoleNumber] = currentHitNumber;
        _currentHoleNumber += 1;

        // opens the end screen UI after 18th hole
        if (_currentHoleNumber >= _startingPositions.Count)
        {
            _uiWindowManager.OpenEndScreen();
        }
        else
        {
            _ballRigidbody.transform.position = _startingPositions[_currentHoleNumber].position;       // teleports the ball to the next hole when called
            _ballRigidbody.velocity = Vector3.zero;                  // resets velocity of the ball to zero
            _ballRigidbody.angularVelocity = Vector3.zero;
        }

        _ballSoundManager.PlayHoleSound();
        currentHitNumber = 0;
        UpdateScoreDisplay();
    }

    // Method to update the strokes for each hole and the total stroke number on the score board
    public void UpdateScoreDisplay()
    {
        string scoreText1 = "";
        string scoreText2 = "";

        for (int i = 0; i < 9; i++)
        {
            if (i < _currentHoleNumber)
            {
                scoreText1 += "HOLE " + (i + 1) + " - " + _previousHitNumbers[i] + "<br>"; // <br> = new line
            }
        }

        for (int i = 9; i < 18; i++)
        {
            if (i < _currentHoleNumber)
            {
                scoreText2 += "HOLE " + (i + 1) + " - " + _previousHitNumbers[i] + "<br>"; // <br> = new line
            }
        }

        _scoreTextColumn1.text = scoreText1;
        _scoreTextColumn2.text = scoreText2;
        _totalScore.text = "Total Strokes: " + totalHitNumber;
        _totalScore2.text = "Total Strokes: " + totalHitNumber;
    }

    public void ResetBallPosition()
    {
        _ballRigidbody.transform.position = _startingPositions[_currentHoleNumber].position;
        _ballRigidbody.velocity = Vector3.zero;
        _ballRigidbody.angularVelocity = Vector3.zero;
    }

    void OnDestroy()
    {
        // Unsubscribe from the reset ball action
        _resetBall.action.performed -= _ => ResetBallPosition();
    }

    void OnEnable()
    {
        _resetBall.action.Enable();
    }

    void OnDisable()
    {
        _resetBall.action.Disable();
    }

    public void RestartGame()
    {
        // Restarts the Game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Quits the game
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}
