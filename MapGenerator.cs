using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    public GameObject[] track;
    private Transform cameraTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 7.62f;
    private int amn = 7;
    private float safeZone = 10.0f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;
    GameDirector gd;

    // Start is called before the first frame update
    private void Start()
    {
        this.gd = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        activeTiles = new List<GameObject>();
        this.cameraTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < amn; i++)
        {
            if (i < 2)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(cameraTransform.position.z  - safeZone > (spawnZ - amn * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(track[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(track[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);

    }

    private int RandomPrefabIndex()
    {
        if (track.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            if (gd.Level == 3 || gd.Level == 6 || gd.Level == 9)
            {
                randomIndex = Random.Range(0, track.Length);
            }
            else
            {
                randomIndex = Random.Range(0, track.Length-1);
            }
            
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
