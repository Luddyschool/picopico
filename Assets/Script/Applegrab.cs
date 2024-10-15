using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Applegrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    [System.Obsolete]
    void OnEnable()
    {
        grabInteractable.onSelectEntered.AddListener(OnGrab);
    }

    [System.Obsolete]
    void OnDisable()
    {
        grabInteractable.onSelectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // When the apple is grabbed, allow it to be affected by physics  
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}
