using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ViewCamera
{
    public Camera cam;
    [Tooltip("Cull Main Lighting")]
    public bool cullLight;
}

public class ViewController : MonoBehaviour 
{
    [Tooltip("Overiew Camera")]
    public Camera overViewCam;
    [Tooltip("View Cameras")]
    public ViewCamera[] smallCameras;
    [Tooltip("View Camera Size")]
    [Range(.1f, .3f)]
    public float size = .2f;
    [Tooltip("Nr. Of Horizontally Aligned View Cameras")]
    [Range(1f, 3f)]
    public int numberOfHorizontal = 2;

    // MapView Cameras are drawn over MapCamera
    private int cameraDepth = 1;
    private int overViewCameraDepth = 0;
    private int fieldOfView = 60;

    private float yPos = 1;
    private float xPos = 0;

    public Light mainLight;

    void Awake()
    {
        foreach (ViewCamera camList in smallCameras)
        {
            if (camList.cullLight)
            {
                camList.cam.gameObject.AddComponent<CullMainLight>();
                camList.cam.gameObject.GetComponent<CullMainLight>().SetMainLight(mainLight);
            }
        }
    }

    void Start()
    {
        PrepareMainCamera();
        PrepareSmallCameras();
    }

    void PrepareMainCamera()
    {
        overViewCam.stereoTargetEye = StereoTargetEyeMask.None;
        overViewCam.depth = overViewCameraDepth;
        overViewCam.targetDisplay = 0;
    }

    void PrepareSmallCameras()
    {
        int counter = smallCameras.Length;
        int index = 0;

        while (counter > 0)
        {
            yPos -= size;
            for (int i = 0; i < numberOfHorizontal; i++)
            {
                xPos = i * size;
                smallCameras[i + index].cam.depth = cameraDepth;
                smallCameras[i + index].cam.fieldOfView = fieldOfView;
                smallCameras[i + index].cam.targetDisplay = 0;
                smallCameras[i + index].cam.GetComponent<AudioListener>().enabled = false;
                smallCameras[i + index].cam.stereoTargetEye = StereoTargetEyeMask.None;
                smallCameras[i + index].cam.rect = new Rect(xPos, yPos, size, size);
                counter--;
            }
            index += numberOfHorizontal;

            /* Bounds checking. Otherwise horizontal could
             * exceed the size of the camera array.
             */
            if (counter < numberOfHorizontal)
            {
                numberOfHorizontal = counter;
            }

        }
    }
}
