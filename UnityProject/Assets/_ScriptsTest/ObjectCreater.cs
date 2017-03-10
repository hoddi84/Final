using UnityEngine;

public class ObjectCreater : MonoBehaviour
{
    private SteamVR_TrackedController controller;
    private PrimitiveType _currentPrimitiveType = PrimitiveType.Sphere;

    public GameObject vrRig;

    private void OnEnable()
    {
        controller = GetComponent<SteamVR_TrackedController>();
        controller.TriggerClicked += HandleTriggerClicked;
        controller.PadClicked += HandlePadClicked;
        controller.Gripped += HandleGripClicked;
    }

    private void OnDisable()
    {
        controller.TriggerClicked -= HandleTriggerClicked;
        controller.PadClicked -= HandlePadClicked;
        controller.Gripped -= HandleGripClicked;
    }

    private void HandleGripClicked(object sender, ClickedEventArgs e)
    {
        vrRig.transform.Translate(0, 1, 0);
    }

    private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    {
        SpawnCurrentPrimitiveAtController();
    }

    private void SpawnCurrentPrimitiveAtController()
    {
        var spawnedPrimitive = GameObject.CreatePrimitive(_currentPrimitiveType);
        spawnedPrimitive.transform.position = transform.position;
        spawnedPrimitive.transform.rotation = transform.rotation;

        spawnedPrimitive.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        if (_currentPrimitiveType == PrimitiveType.Plane)
            spawnedPrimitive.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    private void HandlePadClicked(object sender, ClickedEventArgs e)
    {
        if (e.padY < 0)
            SelectPreviousPrimitive();
        else
            SelectNextPrimitive();
    }

    private void SelectNextPrimitive()
    {
        _currentPrimitiveType++;
        if (_currentPrimitiveType > PrimitiveType.Quad)
            _currentPrimitiveType = PrimitiveType.Sphere;
    }

    private void SelectPreviousPrimitive()
    {
        _currentPrimitiveType--;
        if (_currentPrimitiveType < PrimitiveType.Sphere)
            _currentPrimitiveType = PrimitiveType.Quad;
    }
}