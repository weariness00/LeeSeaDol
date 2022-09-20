using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public Monster monster;

    [HideInInspector] public GameObject[] obj;

    [Range(0,100)]
    public int maxPoolIndex = 100;

    public bool isAllSpawn = false; // 만약 모든 Monster들이 Active 상태라면

    private void Awake()
    {
        CreatMonster();
    }

    void CreatMonster()
    {
        obj = new GameObject[maxPoolIndex];
        for (int i = 0; i < maxPoolIndex; i++)
        {
            obj[i] = Instantiate(monster.Obj);
            obj[i].SetActive(false);
            obj[i].transform.SetParent(transform);
        }
    }

    public void Spawn(int spawnIndex, Vector3 spawnPos)
    {
        for (int i = 0; i < maxPoolIndex; i++)
        {
            if (obj[i].activeSelf)
                continue;

            obj[i].SetActive(true);
            obj[i].transform.position = spawnPos;
            spawnIndex--;

            if (spawnIndex.Equals(0))
            {
                isAllSpawn = false;
                return;
            }
        }

        isAllSpawn = true;
    }

    public void Clear()
    {
        for (int i = 0; i < maxPoolIndex; i++)
        {
            obj[i].SetActive(false);
        }
        isAllSpawn=false; 
    }
}
