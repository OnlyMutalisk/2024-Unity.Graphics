using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Mob : MonoBehaviour
{
    private float speed = GameManager.speed_mob;
    private NavMeshAgent nav;

    private void Awake()
    {
            nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, CharacterAnimation.trans.position, speed * Time.deltaTime);
        nav.SetDestination(CharacterAnimation.trans.position);
    }
}
