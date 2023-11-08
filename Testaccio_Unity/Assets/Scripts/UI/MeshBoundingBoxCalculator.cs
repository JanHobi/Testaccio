using System.Collections.Generic;
using UnityEngine;

public class MeshBoundingBoxCalculator : MonoBehaviour
{
    private List<Vector3> vertices = new List<Vector3>();

    public Rect GetBoundingBoxOnScreen(Mesh mesh, Camera camera) 
    {
        mesh.GetVertices(vertices);
        Rect retVal = Rect.MinMaxRect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);

        for (int i = 0; i < vertices.Count; i++) {
            Vector3 v = camera.WorldToScreenPoint(vertices[i]);
            if (v.x < retVal.xMin) {
                retVal.xMin = v.x;
            }

            if (v.y < retVal.yMin) {
                retVal.yMin = v.y;
            }

            if (v.x > retVal.xMax) {
                retVal.xMax = v.x;
            }

            if (v.y > retVal.yMax) {
                retVal.yMax = v.y;
            }
        }

        return retVal;
    }   
}
