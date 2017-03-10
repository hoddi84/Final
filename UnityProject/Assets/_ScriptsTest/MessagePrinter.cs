using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePrinter : MonoBehaviour {

	void OnEnable()
    {
        EventManager.OnKeyDownE += PressedDownE;
        EventManager.OnKeyUpE += PressedUpE;
        EventManager.OnKeyDownR += PressedDownR;
        EventManager.OnKeyUpR += PressedUpR;
    }

    void OnDisable()
    {
        EventManager.OnKeyDownE -= PressedDownE;
        EventManager.OnKeyUpE -= PressedUpE;
        EventManager.OnKeyDownR -= PressedDownR;
        EventManager.OnKeyUpR -= PressedUpR;
    }

    void PressedDownE()
    {
        print("E pressed down");
    }

    void PressedUpE()
    {
        print("E pressed up");
    }

    void PressedDownR()
    {
        print("R pressed down");
    }

    void PressedUpR()
    {
        print("R pressed up");
    }
}
