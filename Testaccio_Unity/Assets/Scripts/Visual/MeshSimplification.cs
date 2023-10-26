using UnityEngine;
using UnityMeshSimplifier;
using TMPro;

public class MeshSimplification : MonoBehaviour
{
    // public
    [Range(0f, 1f)]
    [SerializeField] public float quality = 0.5f;
    [SerializeField] public TextMeshProUGUI textField;
    [SerializeField] public string objectName;

    // private
    private MeshFilter meshFilter;
    private Mesh originalMesh;
    private float progress = 0f;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        originalMesh = meshFilter.mesh;
    }

    void Update()
    {
        SimplifyMesh();
        ObjectUpdater();
    }

    // simplifies the mesh with the MeshSimplifier package
    void SimplifyMesh()
    {
        Mesh mesh = originalMesh;
        MeshSimplifier simplifier = new MeshSimplifier();
        simplifier.Initialize(mesh);
        simplifier.SimplifyMesh(quality);
        meshFilter.mesh = simplifier.ToMesh();
    }

    // updates the objects name and formats the quality into progress
    void ObjectUpdater()
    {
        progress = quality * 100f;
        progress = Mathf.Round(progress);
        textField.text = objectName + ": " + progress.ToString() + "%";
    }

    // revert back to the original mesh
    [ContextMenu("Revert to Original Mesh")]
    public void RevertToOriginalMesh()
    {
        meshFilter.mesh = originalMesh;
    }
}
