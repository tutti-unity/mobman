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

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(PillsSpawner))]
public class PillsSpawnerEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var spawner = (PillsSpawner) target;
        if (GUILayout.Button("Generate grid"))
        {
            var spawnPoints = serializedObject.FindProperty("spawnPoints");
            spawnPoints.ClearArray();
            for (var x = 0; x < 10; x++)
            {
                for (var y = 0; y < 10; y++)
                {
                    spawnPoints.InsertArrayElementAtIndex(0);
                    spawnPoints.GetArrayElementAtIndex(0).vector3Value = new Vector3(x, y, 0);
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
