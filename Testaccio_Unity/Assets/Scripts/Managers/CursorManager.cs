using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    // public
    [SerializeField] public Texture2D pressedCursor;


    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButton(0))
        {
            // Change the cursor to the pressed cursor texture
            Cursor.SetCursor(pressedCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            // Change the cursor to the default cursor texture
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
