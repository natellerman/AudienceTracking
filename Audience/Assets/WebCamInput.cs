using UnityEngine;

public class WebCamInput : MonoBehaviour
{
    public string webcamName = "Logitech StreamCam"; // Ensure this matches your camera name
    private WebCamTexture webcamTexture;

    void Start()
    {
        // 1. Find the Camera Device
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            if (devices[i].name == webcamName)
            {
                // 2. Initialize Texture
                webcamTexture = new WebCamTexture(devices[i].name, 1920, 1080, 30);
                
                // 3. Apply Texture to Renderer
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.mainTexture = webcamTexture;
                }
                
                // 4. Start Feed
                webcamTexture.Play();
                return;
            }
        }
        Debug.LogError("Webcam " + webcamName + " not found!");
    }
}
