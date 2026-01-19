using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Score score;
    [SerializeField] private float scoreMultiplier;
    private float recordedTime = 1f;
    private bool isHeld = false;

    void Update()
    {
        if (isHeld) recordedTime += Time.deltaTime;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
        score.ScoreCount += Mathf.RoundToInt(scoreMultiplier * recordedTime);
        recordedTime = 1f;
        Debug.Log(score.ScoreCount);
    }
}
