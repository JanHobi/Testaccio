using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    // public
    [SerializeField] public Texture2D hoverCursor;
    [SerializeField] public Texture2D pressedCursor;

    // private
    private Vector2 cursorHotspot;

    void Start()
    {
        // Set the middle of the texture as the cursor's hotspot
        cursorHotspot = new Vector2(hoverCursor.width / 2, hoverCursor.height / 2);

        // Set the cursor to the default cursor on start
        Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            // Change the cursor to the pressed cursor texture
            Cursor.SetCursor(pressedCursor, cursorHotspot, CursorMode.Auto);
            return;
        }

        // Check if the mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Change the cursor to the hover cursor texture
            Cursor.SetCursor(hoverCursor, cursorHotspot, CursorMode.Auto);
        }
        else
        {
            // Revert the cursor back to the default cursor
            Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
        }
    }
}
