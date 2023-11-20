using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{

    private InputDevice targetDevice;
    public List<GameObject> controllerPrefabs;
    private GameObject spawnedController;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        Debug.Log("start checking...devices = " + devices.Count);
        foreach (var item in devices)
        {
            Debug.Log("item.name " + item.name);
            Debug.Log("item characteristic " + item.characteristics);

        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            Debug.Log("target item name " + targetDevice.name);
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        //some devices, like the Valve Index/Occulus, don't initialize until you pick them up. Which can happen after the Start() method runs.
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            // Do what you would like with _targetDevice here
            targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
            if (primaryButtonValue)
                Debug.Log("Pressing Primary Button");

            targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            if (triggerValue > 0.1f)
                Debug.Log("triggerValue pressed " + triggerValue);

            targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
            if (primary2DAxisValue != Vector2.zero)
                Debug.Log("Primary Touchpad" + primary2DAxisValue);
        }
    }
}
