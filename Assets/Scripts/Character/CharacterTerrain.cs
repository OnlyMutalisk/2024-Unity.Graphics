using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTerrain : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        AdjustPlayerHeight();

        if (navMeshAgent != null)
        {
            navMeshAgent.Warp(transform.position); // NavMeshAgent 위치 강제 설정
        }
    }

    void AdjustPlayerHeight()
    {
        Terrain terrain = Terrain.activeTerrain;
        Vector3 playerPosition = transform.position;
        float terrainHeight = terrain.SampleHeight(playerPosition);
        playerPosition.y = terrainHeight + terrain.GetPosition().y;
        transform.position = playerPosition;
    }
}
