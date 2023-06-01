using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public InputActionProperty anyButtonActionRightHand;
    public InputActionProperty anyButtonActionLeftHand;

    private void Start()
    {
        // Enable the actions when the script starts
        anyButtonActionRightHand.action.Enable();
        anyButtonActionLeftHand.action.Enable();

        // Hook up the event handlers
        anyButtonActionRightHand.action.performed += HandleActivationPerformed;
        anyButtonActionLeftHand.action.performed += HandleActivationPerformed;
    }

    private void OnDestroy()
    {
        // Disable the actions when the script is destroyed
        anyButtonActionRightHand.action.Disable();
        anyButtonActionLeftHand.action.Disable();

        // Unhook the event handlers
        anyButtonActionRightHand.action.performed -= HandleActivationPerformed;
        anyButtonActionLeftHand.action.performed -= HandleActivationPerformed;
    }

    private void HandleActivationPerformed(InputAction.CallbackContext obj)
    {
        // Load the main minigolf scene by pressing any button
        SceneManager.LoadScene("MinigolfVR");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // replace this with your preferred input
        {
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            ScreenCapture.CaptureScreenshot("Screenshot-" + timestamp + ".png", 1080);
        }
    }
}
