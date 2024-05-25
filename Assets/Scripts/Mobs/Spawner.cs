using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    // 생성할 몬스터 프리팹은 인스펙터에서 연결합니다.
    public GameObject[] Mobs;
    private bool isCorSpawnerOn = false;
    private float delay = GameManager.delay_spawner;
    private int population_limit = GameManager.population_limit;
    private Transform center;
    private Terrain terrain;
    private float radius = GameManager.radius;
    private float layLength = GameManager.layLength;
    private float obstacleHeightLimit = GameManager.obstacleHeightLimit;
    public static int population_current;

    // 중심 위치는 GameObject 와 같습니다.
    public void Start()
    {
        terrain = Terrain.activeTerrain;
        population_current = 0;
        center = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (population_current < population_limit && isCorSpawnerOn == false)
        {
            StartCoroutine(CorSpawn());
        }
    }

    public IEnumerator CorSpawn()
    {
        isCorSpawnerOn = true;
        Spawn();
        yield return new WaitForSeconds(delay);
        isCorSpawnerOn = false;
    }

    /// <summary>
    /// <br>랜덤 위치에서 랜덤 몬스터를 생성합니다. </br>
    /// <br>딜레이 구현을 위해, CorSpawn 으로 사용합니다.</br>
    /// </summary>
    public void Spawn()
    {
        System.Random rand = new System.Random();
        int index = rand.Next(0, Mobs.Length);
        GameObject Mob = Mobs[index];
        Vector3 spawnPos = GetSpawnPos(center.position, radius);

        Instantiate<GameObject>(Mob, spawnPos, center.rotation);
        population_current++;

        Debug.Log(Mob.name + " 소환");
    }

    /// <summary>
    /// 중심점 반지름 r 이내에서 몬스터 스폰 좌표를 반환합니다.
    /// </summary>
    private Vector3 GetSpawnPos(Vector3 center, float radius)
    {
        Vector3 pos = GetRandPos(center, radius);
        while (CheckPos(pos) == false) { pos = GetRandPos(center, radius); }
        pos.y = terrain.SampleHeight(pos);

        return pos;
    }

    /// <summary>
    /// 중심 좌표에서 반지름 N 이내 랜덤 좌표 반환
    /// </summary>
    private Vector3 GetRandPos(Vector3 center, float radius)
    {
        Vector2 posInCircle = Random.insideUnitCircle * radius;
        return new Vector3(center.x + posInCircle.x, center.y, center.z + posInCircle.y);
    }

    /// <summary>
    /// 트레인 좌표와 레이케스팅 좌표 차이를 검사하여, 몬스터 스폰 타당성을 검사합니다.
    /// </summary>
    private bool CheckPos(Vector3 position)
    {
        Vector3 pos = position;
        float terHeight = terrain.SampleHeight(position);
        pos.y = terHeight;

        RaycastHit hit;

        // 닿은 물체가 limit 보다 작으면 true
        if (Physics.Raycast(pos + Vector3.up * layLength, Vector3.down, out hit, layLength * 2))
        {
            float rayH = hit.point.y;
            if (Mathf.Abs(terHeight - rayH) < obstacleHeightLimit) { return true; }
            else { return false; }
        }

        // 닿은 물체가 없으면
        return true;
    }
}
