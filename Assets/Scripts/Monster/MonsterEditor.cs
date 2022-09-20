using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterSpawner))]
public class MonsterEditor : Editor
{
    MonsterSpawner monsterSpawner_Script;

    int poolIndex;
    int spawnIndex;

    private void Awake()
    {
        monsterSpawner_Script = (MonsterSpawner)target;
    }

    public override void OnInspectorGUI()
    { 
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        poolIndex = EditorGUILayout.IntField("Pool Index", poolIndex);
        spawnIndex = EditorGUILayout.IntField("Spawn Index", spawnIndex);
        if (GUILayout.Button("SpawnMonster"))
        {
            SpawnMonster();            
        }
        else if(GUILayout.Button("Monster Clear"))
        {
            monsterSpawner_Script.monsterPool_Script[poolIndex].Clear();
        }
    }

    void SpawnMonster()
    {
        monsterSpawner_Script.SpawnMonster(poolIndex, spawnIndex);
        DebugControl.Instance.Log(poolIndex + "번째 Spawner " + spawnIndex + "마리 소환");
    }
}