using UnityEngine;

public class BoxAnimator : MonoBehaviour
{
    RectTransform rectTransform;

    Vector2 startSize;
    Vector2 targetSize;
    float elapsed;
    float duration = 1f;
    bool animating;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void AnimateTo(Vector2 target)
    {
        startSize = rectTransform.sizeDelta;
        targetSize = target;
        elapsed = 0f;
        animating = true;
    }

    void Update()
    {
        if (!animating) return;

        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / duration);
        float eased = Mathf.Sin(t * Mathf.PI * 0.5f);

        rectTransform.sizeDelta = Vector2.Lerp(startSize, targetSize, eased);

        if (t >= 1f) animating = false;

    }
}

