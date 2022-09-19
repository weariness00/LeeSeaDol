using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    public const float maxViewOffSet = 300;
    public Transform viewr;

    public static Vector2 viewerPos;
    int chunkSize;
    int chunkVisiavleInViewDistance;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();

    private void Start()
    {
        chunkVisiavleInViewDistance = Mathf.RoundToInt(maxViewOffSet / chunkSize);
    }

    void UpdateVisiableChunks()
    {
        int currentChunkPosX = Mathf.RoundToInt(viewerPos.x / chunkSize);
        int currentChunkPosY = Mathf.RoundToInt(viewerPos.y / chunkSize);

        for (int yOffset = -chunkVisiavleInViewDistance; yOffset <= chunkVisiavleInViewDistance; yOffset++)
        {
            for (int xOffset = -chunkVisiavleInViewDistance; xOffset < chunkVisiavleInViewDistance; xOffset++)
            {
                Vector2 viewdChunkPos = new Vector2(currentChunkPosX + xOffset, currentChunkPosY + yOffset);

                if(terrainChunkDictionary.ContainsKey(viewdChunkPos))
                {

                }
                else
                {
                    terrainChunkDictionary.Add(viewdChunkPos, new TerrainChunk());
                }
            }
        }
    }

    public class TerrainChunk
    {
        GameObject terrain_Obj;
        Vector2 position;
        Bounds bounds;

        public TerrainChunk(Vector2 pos, int size)
        {
            position = pos;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3
        }
    }
}
