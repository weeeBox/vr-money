using UnityEngine;
using UnityEditor;

using System.Collections;

[CustomEditor(typeof(MeshFilter))]
public class MeshFilterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Apply scale"))
        {
            ApplyScale(target as MeshFilter);
        }
    }

    void ApplyScale(MeshFilter filter)
    {
        GameObject go = filter.gameObject;
        Vector3 localScale = go.transform.localScale;

        // scale mesh
        Mesh mesh = Instantiate(filter.sharedMesh) as Mesh;
        mesh.name = go.name;
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertices[i].Scale(localScale);
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        filter.sharedMesh = mesh;

        // scale collider
        BoxCollider collider = go.GetComponent<BoxCollider>();
        if (collider != null)
        {
            Vector3 size = collider.size;
            size.Scale(localScale);
            collider.size = size;
        }

        // revert scale
        go.transform.localScale = Vector3.one;
    }
}
