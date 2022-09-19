using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    public Monster monster;

    [HideInInspector] public GameObject[] obj;

    [Range(0,100)]
    public int maxPoolIndex = 100;

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

    public void Spawn(int spawnIndex)
    {
        for (int i = 0; i < maxPoolIndex; i++)
        {
            if (obj[i].activeSelf)
                continue;

            obj[i].SetActive(true);
            spawnIndex--;

            if (spawnIndex.Equals(0))
                break;
        }
    }
}
