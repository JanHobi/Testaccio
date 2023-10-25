using UnityEngine;
using UnityMeshSimplifier;

public class MeshSimplification : MonoBehaviour
{
    [Range(0f, 1f)]
    public float quality = 0.5f;

    private MeshFilter meshFilter;
    private Mesh originalMesh; // Store a reference to the original mesh

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.mesh; // Store the original mesh
    }

    void Update()
    {
        SimplifyMesh();
    }

    void SimplifyMesh()
    {
        Mesh mesh = originalMesh; // Use the original mesh for simplification
        MeshSimplifier simplifier = new MeshSimplifier();
        simplifier.Initialize(mesh);
        simplifier.SimplifyMesh(quality);
        meshFilter.mesh = simplifier.ToMesh();
    }

    // Function to revert back to the original mesh
    [ContextMenu("Revert to Original Mesh")]
    public void RevertToOriginalMesh()
    {
        meshFilter.mesh = originalMesh; // Set the mesh back to the original mesh
    }
}
