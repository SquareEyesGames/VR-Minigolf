using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIWindowManager : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private float _spawnDistance = 1.5f;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _rightDistanceGrabRay;
    [SerializeField] private InputActionProperty _showButton;

    void Start()
    {
        _settings.SetActive(false);
        _score.SetActive(false);
        _endScreen.SetActive(false);
        _rightDistanceGrabRay.SetActive(false);
    }

    void Update()
    {
        if (_showButton.action.WasPerformedThisFrame())
        {
            bool isAnyPanelActive = _score.activeSelf || _settings.activeSelf;

            if (isAnyPanelActive)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    // toggle between score board an settings panel
    public void ToggleSettingsPanel()
    {
        bool isScorePanelActive = _score.activeSelf;
        bool isSettingsPanelActive = _settings.activeSelf;

        _score.SetActive(!isScorePanelActive);
        _settings.SetActive(isScorePanelActive);

        if (_settings.activeSelf)
        {
            _settings.transform.position = _score.transform.position;
            _settings.transform.rotation = _score.transform.rotation;
        }
    }

    private void OpenMenu()
    {
        _score.SetActive(true);
        _score.transform.position = _head.position + new Vector3(_head.forward.x, 0, _head.forward.z).normalized * _spawnDistance;
        _score.transform.LookAt(new Vector3(_head.position.x, _score.transform.position.y, _head.position.z));
        _score.transform.forward *= -1;   //flips the menu to make it not more spiegelverkehrt anymore
        _rightDistanceGrabRay.SetActive(true); // Enable the distance grab ray
    }

    public void CloseMenu()
    {
        _settings.SetActive(false);
        _score.SetActive(false);
        _rightDistanceGrabRay.SetActive(false); // Disable the distance grab ray
    }

    public void OpenEndScreen()
    {
        _endScreen.SetActive(true);
        _endScreen.transform.position = _head.position + new Vector3(_head.forward.x, 0, _head.forward.z).normalized * _spawnDistance;
        _endScreen.transform.LookAt(new Vector3(_head.position.x, _endScreen.transform.position.y, _head.position.z));
        _endScreen.transform.forward *= -1;   //flips the menu to counter back-to-front view
        _rightDistanceGrabRay.SetActive(true); // Enable the distance grab ray
    }
}
