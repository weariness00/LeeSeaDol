using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [HideInInspector] public List<MonsterPool> monsterPool_Script;

    int maxIndexPool;

    private void Awake()
    {
        SettingMonsterSpawner();
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

    public void SpawnMonster(int pool, int spawn)
    {
        monsterPool_Script[pool].Spawn(spawn);
    }
}
