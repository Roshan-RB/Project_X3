using UnityEngine;

public class CaptureAndSave : MonoBehaviour
{
    public Camera renderCamera;
    public RenderTexture renderTexture;

    void Start()
    {
        // Make sure the render texture is created and assigned to the camera
        renderCamera.targetTexture = renderTexture;
    }

    void Update()
    {
        // Your logic to update the scene

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CaptureAndSaveImage();
        }
    }

    void CaptureAndSaveImage()
    {
        // Ensure the render texture is active and has been rendered
        RenderTexture.active = renderTexture;

        // Create a texture to read from the active render texture
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        // Reset the active render texture
        RenderTexture.active = null;

        // Encode the texture into a PNG or JPEG byte array
        byte[] bytes = texture.EncodeToPNG(); // or texture.EncodeToJPG()

        // Save the byte array as a file
        System.IO.File.WriteAllBytes("CapturedImage.png", bytes);

        Debug.Log("Image captured and saved!");
    }
}
