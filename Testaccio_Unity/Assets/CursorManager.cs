using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    // public
    [SerializeField] public Texture2D selectedCursor;

    // private
    private Vector2 cursorHotspot;

    void Start()
    {
        // Set the middle of the texture as the cursor's hotspot
        cursorHotspot = new Vector2(selectedCursor.width / 2, selectedCursor.height / 2);
        
        // Set the cursor to the default cursor on start
        Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
    }

    void Update()
    {
        // Check if the mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Change the cursor to the custom cursor texture
            Cursor.SetCursor(selectedCursor, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            // Revert the cursor back to the default cursor
            Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
        }
    }
}
