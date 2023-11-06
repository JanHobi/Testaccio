/// Credit Alastair Aitchison
/// Sourced from - https://bitbucket.org/UnityUIExtensions/unity-ui-extensions/issues/123/uilinerenderer-issues-with-specifying

namespace UnityEngine.UI.Extensions
{
    [AddComponentMenu("UI/Extensions/UI Line Connector")]
    [RequireComponent(typeof(UILineRenderer))]
    [ExecuteInEditMode]
    public class UILineConnector : MonoBehaviour
    {

        // The elements between which line segments should be drawn
        public RectTransform[] transforms;
        private Vector3[] previousPositions;
        private RectTransform canvas;
        private RectTransform rt;
        private UILineRenderer lr;

        private void Awake()
        {
            var canvasParent = GetComponentInParent<RectTransform>().GetParentCanvas();
            if (canvasParent != null)
            {
                canvas = canvasParent.GetComponent<RectTransform>();
            }
            rt = GetComponent<RectTransform>();
            lr = GetComponent<UILineRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (transforms == null || transforms.Length < 1)
            {
                return;
            }

            // Calculate positions based on bottom right corner of RectTransform at index 1
            Vector3 bottomRightCorner = transforms[1].TransformPoint(new Vector3(1f, 0f, 0f));
            Vector3[] points = new Vector3[transforms.Length];
            
            for (int i = 0; i < transforms.Length; i++)
            {
                // Use bottom right corner position for index 1, original pivot points for other indices
                if (i == 1)
                {
                    points[i] = bottomRightCorner;
                }
                else
                {
                    points[i] = transforms[i].TransformPoint(transforms[i].pivot);
                }
            }

            // Convert points to canvas space
            Vector2[] canvasPoints = new Vector2[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                canvasPoints[i] = canvas.InverseTransformPoint(points[i]);
            }

            // Assign the converted points to the line renderer
            lr.Points = canvasPoints;
            lr.RelativeSize = false;
            lr.drivenExternally = true;
        }
    }
}