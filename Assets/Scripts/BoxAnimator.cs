using UnityEngine;

public class BoxAnimator : MonoBehaviour
{
    public void AnimateTo(Vector3 targetScale)
    {
        startScale = transform.localScale;
        endScale = targetScale;
        elapsed = 0f;
        isAnimating = true;
    }

    void Update()
    {
        if (!isAnimating) return;

        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / duration);

        // Sine Ease Out
        float eased = Mathf.Sin(t * Mathf.PI * 0.5f);

        transform.localScale = Vector3.Lerp(startScale, endScale, eased);

        if (t >= 1f) isAnimating = false;
    }

}
