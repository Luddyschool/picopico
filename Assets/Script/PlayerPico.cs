using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPico : MonoBehaviour
{
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("NPC"))
        {
            Debug.Log("I Hit A NPC");
        }
    }
}
