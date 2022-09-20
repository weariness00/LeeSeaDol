using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [HideInInspector] public List<MonsterPool> monsterPool_Script;

    public Transform player;

    [SerializeField]float spawnDistance;
    int maxIndexPool;

    private void Awake()
    {
        SettingMonsterSpawner();
        spawnDistance = Mathf.Pow(spawnDistance, 2);
        Debug.Log(spawnDistance);
    }

    void SettingMonsterSpawner()
    {
        int i = 0;
        while (true)
        {
            GameObject obj = transform.GetChild(i).gameObject;

            if (obj.name.Equals("MaxIndexPool"))
                break;

            monsterPool_Script.Add(obj.GetComponent<MonsterPool>());
            i++;
        }
        maxIndexPool = i;
    }

    public void SpawnMonster(int pool, int spawn, Vector3 pos)
    {
        if (monsterPool_Script[pool].isAllSpawn)
            return;

        monsterPool_Script[pool].Spawn(spawn, pos);
    }

    public void SpawnMonster(int pool, int spawn)
    {
        float random_X = spawnDistance - Random.Range(1, spawnDistance + 1);
        float random_Y = spawnDistance - random_X;

        random_X = Mathf.Sqrt(random_X);
        random_Y = Mathf.Sqrt(random_Y);

        random_X *= Random.Range(0, 1 + 1) == 0 ? -1 : 1;
        random_Y *= Random.Range(0, 1 + 1) == 0 ? -1 : 1;

        DebugControl.Instance.Log(random_X + " : " + random_Y + " = " + (Mathf.Pow(random_X,2) + Mathf.Pow(random_Y, 2)));

        Vector3 pos = new Vector3(player.position.x + random_X, player.position.y + random_Y, 0);
        SpawnMonster(pool, spawn, pos);
    }
}
