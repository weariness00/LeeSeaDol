using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    static GenerateGrid instance;

    public static GenerateGrid Instance 
    { 
        get 
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    public GameObject terrain_Obj;
    public GameObject objectToSpawn;
    public GameObject player;

    [SerializeField]int worldSize_X = 5;
    [SerializeField]int worldSize_Y = 5;
    [SerializeField]float GridOffset = 10.0f;

    public int terrainSize = 100;

    Vector3 startPosition;
    Hashtable blockContainer = new Hashtable();

    List<Vector3> blockPosition = new List<Vector3>();

    [Header("랜덤하게 소환할 Object(OR 장애물) Index")]
    [SerializeField] int randomSpawnObjectIndex = 10;

    private void Start()
    {
        if (instance == null)
            instance = this;

        //startPosition = player.transform.position;
        //SetGrid(startPosition.x, startPosition.y);
        //SpawnObject();
    }
    //private void Update()
    //{
    //    if (Mathf.Abs(PlayerMove_X) >= GridOffset || Mathf.Abs(PlayerMove_Y) >= GridOffset)
    //    {
    //        SetGrid(PlayerLocation_X, PlayerLocation_Y);
    //    }
    //}


    void SpawnObject()
    {
        for (int i = 0; i < randomSpawnObjectIndex; i++)
        {
            GameObject toPlaceObject = Instantiate(objectToSpawn, ObjectSpawnLocation(), Quaternion.identity);
        }
    }

    Vector3 ObjectSpawnLocation()
    {
        int randIndex = Random.Range(0, blockPosition.Count);

        Vector3 pos = new Vector3(
            blockPosition[randIndex].x,
            blockPosition[randIndex].y + 0.5f,
            1
            );

        blockPosition.RemoveAt(randIndex);
        return pos;
    }

    void SetGrid(float nowPos_X, float nowPos_Y)
    {
        for (int x = -worldSize_X; x < worldSize_X; x++)
        {
            for (int y = -worldSize_Y; y < worldSize_Y; y++)
            {
                Vector3 pos = new Vector3(x * GridOffset + nowPos_X, y * GridOffset + nowPos_Y, 1);

                if (!blockContainer.ContainsKey(pos))
                {
                    GameObject block = Instantiate(terrain_Obj, pos, Quaternion.identity) as GameObject;

                    blockContainer.Add(pos, block);
                    blockPosition.Add(block.transform.position);
                    block.transform.SetParent(this.transform);
                }
            }
        }
    }

    public int PlayerMove_X
    {
        get => (int)(player.transform.position.x - startPosition.x);
    }

    int PlayerMove_Y
    {
        get => (int)(player.transform.position.y - startPosition.y);
    }

    int PlayerLocation_X
    {
        get => (int)Mathf.Floor(player.transform.position.x);
    }

    int PlayerLocation_Y
    {
        get => (int)Mathf.Floor(player.transform.position.y);
    }
}
