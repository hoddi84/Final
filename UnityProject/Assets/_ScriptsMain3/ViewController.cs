using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ViewCamera
{
    public Camera cam;
    public bool cullMainLight;
}

public class ViewController : MonoBehaviour 
{
    public Camera mapCamera;
    public Light mainLight;

    /*
     * Settings for the small camereas drawn on top
     * of the main overview camera. Where smallSize is
     * the size of the small cameras, and the smallHorizontal
     * is the amount of horizontal small cameras placed on
     * the screen.
     */
    [Header("Camera Settings")]
    public ViewCamera[] smallCameras;
    [Range(.1f, .3f)]
    public float smallSize = .2f;
    [Range(1f, 3f)]
    public int smallHorizontal = 2;

    /*
     * Small Cameras are drawn over the MapView camera,
     * so their depth is set higher.
     */
    private int smallCameraDepth = 1;
    private int overViewCameraDepth = 0;
    private int fieldOfView = 60;

    private float yPos = 1;
    private float xPos = 0;

    void Awake()
    {
        foreach (ViewCamera camList in smallCameras)
        {
            if (camList.cullMainLight)
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
        mapCamera.stereoTargetEye = StereoTargetEyeMask.None;
        mapCamera.depth = overViewCameraDepth;
        mapCamera.targetDisplay = 0;
    }

    void PrepareSmallCameras()
    {
        int counter = smallCameras.Length;
        int index = 0;

        while (counter > 0)
        {
            yPos -= smallSize;
            for (int i = 0; i < smallHorizontal; i++)
            {
                xPos = i * smallSize;
                smallCameras[i + index].cam.depth = smallCameraDepth;
                smallCameras[i + index].cam.fieldOfView = fieldOfView;
                smallCameras[i + index].cam.targetDisplay = 0;
                smallCameras[i + index].cam.GetComponent<AudioListener>().enabled = false;
                smallCameras[i + index].cam.stereoTargetEye = StereoTargetEyeMask.None;
                smallCameras[i + index].cam.rect = new Rect(xPos, yPos, smallSize, smallSize);
                counter--;
            }
            index += smallHorizontal;

            /* 
             * Bounds checking. Otherwise horizontal could
             * exceed the size of the camera array.
             */
            if (counter < smallHorizontal)
            {
                smallHorizontal = counter;
            }

        }
    }
}
