using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabAndPlace : MonoBehaviour
{
    public Transform targetContainer; // 目标容器的Transform
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grabInteractable.onSelectExited.RemoveListener(OnRelease);
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // 放置对象到目标容器中
        transform.SetParent(targetContainer);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}
