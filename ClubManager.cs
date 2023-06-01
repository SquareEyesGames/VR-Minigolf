using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ClubManager : MonoBehaviour
{
    [SerializeField] private InputActionProperty _gripAction;
    [SerializeField] private GameObject _club;

    void Start()
    {
        _club.SetActive(false);

        // When the grip button is pressed, call the HandleGripPressed method
        _gripAction.action.performed += _ => HandleGripPressed();

        // When the grip button is released, call the HandleGripReleased method
        _gripAction.action.canceled += _ => HandleGripReleased();
    }

    void HandleGripPressed()
    {
        // Make the club active when the grip button is pressed
        _club.SetActive(true);
    }

    void HandleGripReleased()
    {
        // Make the club inactive when the grip button is released
        _club.SetActive(false);
    }

    void OnEnable()
    {
        _gripAction.action.Enable();
    }

    void OnDisable()
    {
        _gripAction.action.Disable();
    }

    void OnDestroy()
    {
        // Unsubscribe from the grip action events
        _gripAction.action.performed -= _ => HandleGripPressed();
        _gripAction.action.canceled -= _ => HandleGripReleased();
    }
}
