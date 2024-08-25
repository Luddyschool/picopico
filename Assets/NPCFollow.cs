using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    public bool isFollowingPlayer;
    public Transform followingPosition;
    private NavMeshAgent myAgent;
    
    // Update is called once per frame

    private void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            StartToFollowPlayer();
        }
    }

    public void StartToFollowPlayer()
    {
        myAgent.SetDestination(followingPosition.position);
    }
}
