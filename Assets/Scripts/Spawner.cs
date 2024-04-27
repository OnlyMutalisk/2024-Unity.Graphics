using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    // 생성할 몬스터 프리팹은 인스펙터에서 연결합니다.
    public GameObject[] Mobs;
    private bool isCorSpawnerOn = false;
    private float delay = GameManager.delay_spawner;
    private int population_limit = GameManager.population_limit;
    public static int population_current = 0;
    private Transform pos;

    // 생성 위치는 GameObject 와 같습니다.
    public void Start()
    {
        pos = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (population_current < population_limit && isCorSpawnerOn == false)
        {
            StartCoroutine(CorSpawn());
        }
    }

    /// <summary>
    /// <br>랜덤하게 몬스터를 생성합니다. </br>
    /// <br>딜레이 구현을 위해, CorSpawn 으로 사용합니다.</br>
    /// </summary>
    public void Spawn()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(0, Mobs.Length - 1);
        GameObject Mob = Mobs[index];

        Instantiate<GameObject>(Mob, pos.position, pos.rotation);
        population_current++;

        Debug.Log(Mob.name + " 소환");
    }

    public IEnumerator CorSpawn()
    {
        isCorSpawnerOn = true;
        Spawn();
        yield return new WaitForSeconds(delay);
        isCorSpawnerOn = false;
    }
}
