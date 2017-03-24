using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewController : MonoBehaviour {

    [Tooltip("MapView Cameras")]
    public Camera[] smallCameras;

    [Tooltip("Camera size")]
    public float size = .2f;

    [Tooltip("Field of View")]
    public float fieldOfView = 60f;

    // MapView Cameras are drawn over MapCamera
    private int cameraDepth = 1;

    private float yPos;
    private float xPos;

    public int horizontal;
    public int vertical;


    void Start()
    {
        TestArrange();
    }

    void TestArrange()
    {
        int counter = smallCameras.Length;
        while (counter > 0)
        {

            for (int i = 0; i < horizontal; i++)
            {
                xPos = i * size;
                yPos = 1 - size;
                smallCameras[i].depth = cameraDepth;
                smallCameras[i].fieldOfView = fieldOfView;
                smallCameras[i].GetComponent<AudioListener>().enabled = false;
                smallCameras[i].stereoTargetEye = StereoTargetEyeMask.None;
                smallCameras[i].rect = new Rect(xPos, yPos, size, size);
                counter--;
            }

        }
    }
    // Maximum of 4 Cameras.
    void ArrangeCameras()
    {
        for (int i = 0; i < smallCameras.Length; i++)
        {
            xPos = i * size;
            yPos = 1 - size;
            smallCameras[i].depth = cameraDepth;
            smallCameras[i].fieldOfView = fieldOfView;
            smallCameras[i].GetComponent<AudioListener>().enabled = false;
            smallCameras[i].stereoTargetEye = StereoTargetEyeMask.None;
            smallCameras[i].rect = new Rect(xPos, yPos, size, size);
        }
    }
}
