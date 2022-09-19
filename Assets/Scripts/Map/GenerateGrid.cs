using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    public GameObject block_Obj;
    public GameObject objectToSpawn;
    public GameObject player;

    Vector2 worldSize = new Vector2(10, 10);
    int noisHeight = 5;
    float GridOffset = 1.1f;

    Vector3 startPosition;
    Hashtable blockContainer = new Hashtable();

    List<Vector3> blockPosition = new List<Vector3>();

    private void Start()
    {
        for (int x = 0; x < worldSize.x; x++)
        {
            for (int y = 0; y < worldSize.y; y++)
            {
                Vector3 pos = new Vector3(x * GridOffset, y * GridOffset, 0);

                GameObject block = Instantiate(block_Obj, pos, Quaternion.identity) as GameObject;

                //blockContainer.Add(pos, block);
                //blockPosition.Add(block.transform.position);
                block.transform.SetParent(this.transform);
            }
        }
    }

    //private void Start()
    //{
    //    for (int x = -worldSizeX; x < worldSizeX; x++)
    //    {
    //        for (int z = -worldSizeZ; z < worldSizeZ; z++)
    //        {
    //            Vector3 pos = new Vector3(x * GridOffset, GenerateNoise(x, z, 8f) * noisHeight, z * GridOffset);

    //            GameObject block = Instantiate(block_Obj, pos, Quaternion.identity) as GameObject;

    //            blockContainer.Add(pos, block);
    //            blockPosition.Add(block.transform.position);
    //            block.transform.SetParent(this.transform);
    //        }
    //    }
    //    SpawnObject();
    //}

    //private void Update()
    //{
    //    if(Mathf.Abs(xPlayerMove) >=1 || Mathf.Abs(zPlayerMove) >= 1)
    //    {
    //        for (int x = -worldSizeX; x < worldSizeX; x++)
    //        {
    //            for (int z = -worldSizeZ; z < worldSizeZ; z++)
    //            {
    //                Vector3 pos = new Vector3(x + xPlayerLocation, GenerateNoise(x, z, 8f) * noisHeight, z + zPlayerLocation);

    //                if(!blockContainer.ContainsKey(pos))
    //                {
    //                    GameObject block = Instantiate(block_Obj, pos, Quaternion.identity) as GameObject;

    //                    blockContainer.Add(pos, block);
    //                    blockPosition.Add(block.transform.position);
    //                    block.transform.SetParent(this.transform);
    //                }

    //            }
    //        }
    //    }
    //}

    //public int xPlayerMove
    //{
    //    get => (int)(player.transform.position.x - startPosition.x);
    //}

    //int zPlayerMove
    //{
    //    get => (int)(player.transform.position.z - startPosition.z);
    //}

    //int xPlayerLocation
    //{
    //    get => (int)Mathf.Floor(player.transform.position.x);
    //}

    //int zPlayerLocation
    //{
    //    get => (int)Mathf.Floor(player.transform.position.z);
    //}

    //void SpawnObject()
    //{
    //    for (int c = 0; c < 20; c++)
    //    {
    //        GameObject toPlace_Obj = Instantiate(objectToSpawn, ObjectSpawnLocation(), Quaternion.identity);
    //    }
    //}
}
