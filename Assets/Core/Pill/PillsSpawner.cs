using System.Collections.Generic;
using UnityEngine;

public class PillsSpawner : MonoBehaviour
{
    [SerializeField] private List<Vector3> spawnPoints = new List<Vector3>();
    [SerializeField] private Pill pillPrefab;
    
    void Start()
    {
        foreach (var spawnPoint in spawnPoints)
        {
            Instantiate(pillPrefab, spawnPoint, Quaternion.identity);
        }
    }
}
