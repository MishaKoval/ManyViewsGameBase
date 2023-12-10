using UnityEngine;

namespace Core.UI
{
    public class SafeArea : MonoBehaviour
    {
        private RectTransform panel;
        private Rect lastSafeArea = new(0, 0, 0, 0);
        private Vector2Int lastScreenSize = new(0, 0);
        private ScreenOrientation lastOrientation = ScreenOrientation.AutoRotation;
        [SerializeField] private bool conformX = true;
        [SerializeField] private bool conformY = true;
        [SerializeField] private bool logging;

        private void Awake()
        {
            panel = GetComponent<RectTransform>();
            if (panel == null)
            {
                Debug.LogError("Cannot apply safe area - no RectTransform found on " + name);
                Destroy(gameObject);
            }
            Refresh();
        }

        private void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            var safeArea = GetSafeArea();

            if (safeArea != lastSafeArea
                || Screen.width != lastScreenSize.x
                || Screen.height != lastScreenSize.y
                || Screen.orientation != lastOrientation)
            {
                lastScreenSize.x = Screen.width;
                lastScreenSize.y = Screen.height;
                lastOrientation = Screen.orientation;
                ApplySafeArea(safeArea);
            }
        }

        private Rect GetSafeArea()
        {
            var safeArea = Screen.safeArea;
            return safeArea;
        }

        private void ApplySafeArea(Rect r)
        {
            lastSafeArea = r;
            
            if (!conformX)
            {
                r.x = 0;
                r.width = Screen.width;
            }
            
            if (!conformY)
            {
                r.y = 0;
                r.height = Screen.height;
            }
            
            if (Screen.width > 0 && Screen.height > 0)
            {
                var anchorMin = r.position;
                var anchorMax = r.position + r.size;
                anchorMin.x /= Screen.width;
                anchorMin.y /= Screen.height;
                anchorMax.x /= Screen.width;
                anchorMax.y /= Screen.height;
                
                if (anchorMin.x >= 0 && anchorMin.y >= 0 && anchorMax.x >= 0 && anchorMax.y >= 0)
                {
                    panel.anchorMin = anchorMin;
                    panel.anchorMax = anchorMax;
                }
            }

            if (logging)
            {
                Debug.LogFormat("New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}",
                    name, r.x, r.y, r.width, r.height, Screen.width, Screen.height);
            }
        }
    }
}