using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationPlacer : MonoBehaviour
{
    public Transform Player;
    public LocationChunk[] ChunkPrefabs;

    private List<LocationChunk> spawnedChanks = new List<LocationChunk>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SpawnChunk()
    {
        LocationChunk SpawnNewChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

    }
}
