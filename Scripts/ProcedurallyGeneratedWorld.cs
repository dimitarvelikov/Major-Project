using System.Collections.Generic;
using UnityEngine;

public class ProcedurallyGeneratedWorld : MonoBehaviour
{
    public GameObject[] pathPrefabs;
    private Transform player;
    private List<GameObject> renderedPaths;

    //set some distance between the shark and the first spawned prefab
    private float spawnZlocation = 40f;
    //the actual pathLength is 4.85f but i left some space between the different prefabs
    private const float pathLength = 6f;
    private const int pathCount = 5;
    //keep the index of the last prefab in order to prevent spawning of two equal sequent prefabs
    private int lastPath;



    // Use this for initialization
    private void Start()
    {
        //set a value greater than the  pathPrefab array size to prevent == values for the first prefab
        lastPath = 99;

        //Initialise an array for keeping a reference and easy removal
        renderedPaths = new List<GameObject>();

        //Keep a reference to the player position on the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Spawn several prefabs in front of the player
        for (int x = 0; x < pathCount; ++x)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //If the player reach a certain position
        if (player.position.z + 50 > (spawnZlocation - pathCount * pathLength))
        {
            //Spawn prefab in the front
            SpawnTile();
            //Remove a prefab from behind
            DeleteTile();
        }
    }

    //Generate new prefab on the Scene in front of the player character's path
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject obj = Instantiate(pathPrefabs[RandomInt()]) as GameObject;
        obj.transform.SetParent(transform);
        obj.transform.position = Vector3.forward * spawnZlocation;
        spawnZlocation += pathLength * pathCount;

        renderedPaths.Add(obj);
    }

    //Remove the last prefab on the Scene because it is already behind the player
    private void DeleteTile()
    {
        Destroy(renderedPaths[0]);
        renderedPaths.RemoveAt(0);
    }

    //Generate and return a random integer between 0 and the size of pathPrefabs array
    private int RandomInt()
    {
        int nextPrefab;// = Random.Range(0, pathPrefabs.Length;
        do
        {
            nextPrefab = Random.Range(0, pathPrefabs.Length);
        } while (nextPrefab == lastPath);

        //Debug.Log("last is: " + lastPath + ", next is: " + nextPrefab);
        lastPath = nextPrefab;

        return lastPath;
    }
}