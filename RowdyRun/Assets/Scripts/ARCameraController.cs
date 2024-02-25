using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCameraController : MonoBehaviour
{
    private ARCameraManager arCameraManager;

    void Start()
    {
        // Get the ARCameraManager component
        arCameraManager = GetComponent<ARCameraManager>();

        // Enable ARCameraManager if found
        if (arCameraManager != null)
        {
            arCameraManager.enabled = true;
        }
        else
        {
            Debug.LogError("ARCameraManager not found on GameObject. Make sure to attach this script to a GameObject with ARCameraManager component.");
        }
    }
}
