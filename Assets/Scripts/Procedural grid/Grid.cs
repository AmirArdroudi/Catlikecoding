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
        Generate();
    }
    void Start()
    {

    }
    private IEnumerable Generate()
    {
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        GetComponent<MeshFilter>().mesh = mesh;
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
    }
    // Update is called once per frame
    void Update()
    {

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
