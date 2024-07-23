using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (var spawnPoint in spawnPoints)
        {
            Gizmos.DrawSphere(spawnPoint, 0.1f);
        }
    }
}

#if UNITY_EDITOR
[UnityEditor.CustomEditor(typeof(PillsSpawner))]
public class PillsSpawnerEditor : UnityEditor.Editor
{
    private Vector3 origin = Vector3.zero;
    private float cellSize = 1;
    private Vector2Int gridSize = new(10, 10);
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var spawner = (PillsSpawner) target;
        
        origin = EditorGUILayout.Vector3Field("Origin", origin);
        cellSize = EditorGUILayout.FloatField("Gap", cellSize);
        gridSize = EditorGUILayout.Vector2IntField("Grid size", gridSize);
        
        if (GUILayout.Button("Generate grid") && EditorUtility.DisplayDialog("Generate grid", "Are you sure?", "Yes", "No"))
        {
            var spawnPoints = serializedObject.FindProperty("spawnPoints");
            spawnPoints.ClearArray();
            for (var x = 0f; x < gridSize.x * cellSize; x += cellSize)
            {
                for (var y = 0f; y < gridSize.y * cellSize; y += cellSize)
                {
                    spawnPoints.InsertArrayElementAtIndex(0);
                    spawnPoints.GetArrayElementAtIndex(0).vector3Value = origin + new Vector3(x, y, 0);
                }
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
