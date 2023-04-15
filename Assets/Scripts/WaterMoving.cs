using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMoving : MonoBehaviour
{
    [SerializeField] float waterSpeed = 1f;
    [SerializeField] float waveHeight = 0.1f;
    [SerializeField] float waveFrequency = 1f;
    public float xOffsetScale = 0.5f;

    Mesh mesh;
    Vector3[] vertices;
    Vector3[] normals;
    Vector2[] uvs;
    int[] triangles;

    private void Start()
    {
        MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        // Create a plane with 10 x 10 vertices
        int width = 10;
        int height = 10;

        vertices = new Vector3[(width + 1) * (height + 1)];
        normals = new Vector3[vertices.Length];
        uvs = new Vector2[vertices.Length];
        triangles = new int[width * height * 6];

        for (int i = 0, y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++, i++)
            {
                vertices[i] = new Vector3(x, 0, y);
                normals[i] = Vector3.up;
                uvs[i] = new Vector2((float)x / width, (float)y / height);
            }
        }

        for (int ti = 0, vi = 0, y = 0; y < height; y++, vi++)
        {
            for (int x = 0; x < width; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + width + 1;
                triangles[ti + 5] = vi + width + 2;
            }
        }

        mesh.vertices = vertices;
        mesh.normals = normals;
        mesh.uv = uvs;
        mesh.triangles = triangles;
    }

    private void Update()
    {
        float phaseShift = (2 * Mathf.PI) / (vertices.Length / 4); // Calculate the phase shift for one quarter of the plane

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];

            // Calculate the phase shift for this vertex based on its position on the plane
            float xPhase = Mathf.Sin(vertex.x * phaseShift);
            float yPhase = Mathf.Sin(vertex.z * phaseShift);

            // Use the phase shift to calculate the wave height
            vertex.y = Mathf.Sin(Time.time * waveFrequency + xPhase + yPhase + i * 0.1f) * waveHeight;
            vertices[i] = vertex;
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();

        float xOffset = Mathf.Sin(Time.time * waterSpeed) * xOffsetScale;
        GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(xOffset, 0f);
    }
}
