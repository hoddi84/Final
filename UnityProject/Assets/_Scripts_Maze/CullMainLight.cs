using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Gives us the ability to cull the main
 * light of the scene to chosen cameras.
 */
public class CullMainLight : MonoBehaviour
{

    private Light mainLight;

    void Start()
    {
        mainLight.enabled = true;
    }

    void OnPreCull()
    {
        mainLight.enabled = false;
    }

    void OnPostRender()
    {
        mainLight.enabled = true;
    }

    public void SetMainLight(Light light) 
    {
        mainLight = light;
    }
}