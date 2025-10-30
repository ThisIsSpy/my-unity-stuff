using System.Collections;
using UnityEngine;

[RequireComponent (typeof(RectTransform))]
public class SafeAreaFitter : MonoBehaviour
{
    private RectTransform _rootPanel;
    private Rect _lastSavedRect = new(0, 0, 0, 0);

    private void Awake()
    {
        _rootPanel = GetComponent<RectTransform>();
        Redraw();
    }

    private void Update()
    {
        Rect safeArea = Screen.safeArea;
        if (safeArea != _lastSavedRect)
        {
            _lastSavedRect = safeArea;
            StartCoroutine(RedrawCoroutine());
        }
    }

    private void Redraw()
    {
        Rect safeArea = Screen.safeArea;
        Vector2 anchorMin = safeArea.position;
        Vector2 anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        _rootPanel.anchorMin = anchorMin;
        _rootPanel.anchorMax = anchorMax;

        _rootPanel.offsetMin = Vector2.zero;
        _rootPanel.offsetMax = Vector2.zero;
    }

    private IEnumerator RedrawCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Redraw();
        Debug.Log(Screen.safeArea);
    }
}
