using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TroupeSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> troupsPrefabs;
    [SerializeField] private float troupsSpawnAmount;
    [SerializeField] private float troupsSpawnDelay;
    [SerializeField] private Vector3 troupsMaxOffset, troupsTargetLocation;
    [SerializeField] private Vector3[] troupsSpawnPoints;

    private float LastTime = 0;


    private void Update()
    {
        if (Time.time > LastTime + troupsSpawnDelay)
        {
            LastTime = Time.time;

            for (int i = 0; i < troupsSpawnAmount; i++)
            {
                Vector3 troupOffset = new Vector3(Random.Range(-troupsMaxOffset.x, troupsMaxOffset.x), 0, Random.Range(-troupsMaxOffset.z, troupsMaxOffset.z));

                int troupIndex = Random.Range(0, troupsPrefabs.Count);
                GameObject newTroup = Instantiate(troupsPrefabs[troupIndex], troupsSpawnPoints[Random.Range(0, troupsSpawnPoints.Length)] + troupOffset, Quaternion.identity);

                ObjectContainer.instance.AddTrope(newTroup);
            }
        }
    }
}
