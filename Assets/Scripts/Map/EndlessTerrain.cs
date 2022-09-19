using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EndlessTerrain : MonoBehaviour
{
    public const float maxViewDistance = 100;
    public Transform viewer;

    public static Vector2 viewerPosition;
    int terrainSize;
    int terrainVisibleInViewDistance;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();
    List<TerrainChunk> terrainChunksVisibleLastUpdate = new List<TerrainChunk>();

    private void Start()
    {
        terrainSize = GenerateGrid.Instance.terrainSize;
        terrainVisibleInViewDistance = Mathf.RoundToInt(maxViewDistance/ terrainSize);
    }

    private void Update()
    {
        viewerPosition = new Vector2(viewer.position.x, viewer.position.y);
        UpdateVisibleTerrains();
    }

    void UpdateVisibleTerrains()
    {
        for (int i = 0; i < terrainChunksVisibleLastUpdate.Count; i++)
        {
            terrainChunksVisibleLastUpdate[i].SetVisible(false);
        }
        terrainChunksVisibleLastUpdate.Clear();

        int currentTerrain_PosX = Mathf.RoundToInt(viewerPosition.x / terrainSize);
        int currentTerrain_PosY = Mathf.RoundToInt(viewerPosition.y / terrainSize);

        for (int yOffset = -terrainVisibleInViewDistance; yOffset <= terrainVisibleInViewDistance; yOffset++)
        {
            for (int xOffset = -terrainVisibleInViewDistance; xOffset <= terrainVisibleInViewDistance; xOffset++)
            {
                Vector2 viewedTerrainPos = new Vector2(currentTerrain_PosX + xOffset, currentTerrain_PosY + yOffset);

                if(terrainChunkDictionary.ContainsKey(viewedTerrainPos))
                {
                    terrainChunkDictionary[viewedTerrainPos].UpdateTerrtainChunk();
                    if (terrainChunkDictionary[viewedTerrainPos].IsVisible())
                    {
                        terrainChunksVisibleLastUpdate.Add(terrainChunkDictionary[viewedTerrainPos]);
                    }
                }
                else
                {
                    terrainChunkDictionary.Add(viewedTerrainPos, new TerrainChunk(viewedTerrainPos, terrainSize,transform));
                }
            }
        }
    }

    public class TerrainChunk
    {
        GameObject meshObject;
        Vector2 position;
        Bounds bounds;

        public TerrainChunk(Vector2 pos, int size, Transform parent)
        {
            position = pos * size;
            bounds = new Bounds(position, Vector2.one * size);
            Vector3 pos_V3 = new Vector3(position.x, position.y, 0);

            meshObject = Instantiate(GenerateGrid.Instance.terrain_Obj);
            meshObject.transform.position = pos_V3;
            meshObject.transform.localScale = Vector3.one * size / 1f;
            meshObject.transform.parent = parent;
            SetVisible(false);
        }

        public void UpdateTerrtainChunk()
        {
            float viewerDstFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPosition));
            bool visible = viewerDstFromNearestEdge <= maxViewDistance;
            SetVisible(visible);
        }

        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }

        public bool IsVisible()
        {
            return meshObject.activeSelf;
        }
    }
}
