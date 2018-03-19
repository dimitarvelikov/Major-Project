using System.Collections.Generic;
using UnityEngine;

public class ProcedurallyGeneratedWorld : MonoBehaviour
{
    public GameObject[] pathPrefabs;
    private Transform player;
    private float spawnZlocation = 0.0f;
    private const float pathLength = 4.85f;
    private const int pathCount = 5;

    private List<GameObject> renderedPaths;

    // Use this for initialization
    private void Start()
    {
        renderedPaths = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int x = 0; x < pathCount; ++x)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (player.position.z + 50 > (spawnZlocation - pathCount * pathLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }


    private void SpawnTile(int prefabIndex = -1)
    {

        GameObject obj = Instantiate(pathPrefabs[RandomInt()]) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * spawnZlocation;
        spawnZlocation += pathLength * pathCount;

        renderedPaths.Add(obj);
    }


    private void DeleteTile()
    {
        Destroy(renderedPaths[0]);
        renderedPaths.RemoveAt(0);
    }


    private int RandomInt()
    {
        return Random.Range(0, pathPrefabs.Length);
    }
}
