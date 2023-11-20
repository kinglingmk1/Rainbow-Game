using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    [SerializeField]
    Animator handAnimator;
    public InputActionProperty pinchAnimationActor;
    public InputActionProperty gripAnimationAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = pinchAnimationActor.action.ReadValue<float>();
        Debug.Log("triggerValue: " + triggerValue);
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        Debug.Log("gripValue: " + gripValue);
        handAnimator.SetFloat("Grip", gripValue);
    }
}
