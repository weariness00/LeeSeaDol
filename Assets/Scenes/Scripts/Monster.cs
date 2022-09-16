using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Monster", menuName = "ScriptableObject/Monster")]
public class Monster : ScriptableObject
{
    public int id;
    public GameObject Obj;
    public Image image;

    public MonsterStat stat;
}

[System.Serializable]
public class MonsterStat
{
    public int maxHp;
    public int maxMp;
    public int hp;
    public int mp;

    public int damage;
    public int speed;
}