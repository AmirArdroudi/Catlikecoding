using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Grid : MonoBehaviour
{
    [Tooltip("Size of the grid")]
    public int xSize, ySize;
    private Vector3[] vertices;
    private Mesh mesh;
    private void Awake()
    {
        StartCoroutine(Generate());
    }
    private IEnumerator Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);

        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        // give the dots a position
        for (int i = 0, x = 0; x <= xSize; x++)
        {
            for (int y = 0; y <= ySize; y++, i++)
            {
                vertices[i] = new Vector3(x, y, 0);
                yield return wait;
            }
        }
        mesh.vertices = vertices;

        int[] triangles = new int[6];
        triangles[0] = 0;
        triangles[3] = triangles[2] = 1;
        triangles[4] = triangles[1] = ySize + 1;
        triangles[5] = ySize + 2;


        mesh.triangles = triangles;
    }


    // ------------------ Editor helper functions ------------------
    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;
        Gizmos.color = Color.green;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(transform.TransformPoint(vertices[i]), 0.1f);
        }
    }
    private void OnDrawGizmosSelected()
    {

    }
}
