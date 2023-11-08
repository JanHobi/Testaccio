using UnityEngine;
using UnityEngine.UI;

public class DrawBoundingBox : MonoBehaviour {
    public GameObject boundingBoxCalculator; // Reference to the GameObject with the provided script
    public GameObject gameObject; // Reference to your Mesh
    public Camera camera; // Reference to your Camera
    public Canvas canvas; // Reference to your Canvas component
    public Image rectangleImage; // Reference to your UI Image element
    private Mesh mesh;

    void Start()
    {
        // get the mesh from the game object
        mesh = gameObject.GetComponent<MeshFilter>().mesh;
        
    }

    void Update() 
    {
        // Get the bounding box in screen coordinates
        Rect screenRect = boundingBoxCalculator.GetComponent<MeshBoundingBoxCalculator>().GetBoundingBoxOnScreen(mesh, camera);

        // Convert screen coordinates to canvas coordinates
        Vector2 minCanvasPos, maxCanvasPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, new Vector2(screenRect.xMin, screenRect.yMin), camera, out minCanvasPos);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, new Vector2(screenRect.xMax, screenRect.yMax), camera, out maxCanvasPos);

        // Set the RectTransform of the UI Image
        RectTransform imageRectTransform = rectangleImage.rectTransform;
        imageRectTransform.sizeDelta = new Vector2(Mathf.Abs(maxCanvasPos.x - minCanvasPos.x), Mathf.Abs(maxCanvasPos.y - minCanvasPos.y));
        imageRectTransform.anchoredPosition = minCanvasPos + imageRectTransform.sizeDelta / 2f;

        // Optionally, you can set other properties of the image such as color, border, etc.
    }
}
