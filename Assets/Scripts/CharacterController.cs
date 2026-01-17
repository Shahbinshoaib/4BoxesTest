using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector3 startScale;
    float targetScale;
    float elapsed;
    float duration = 1f;
    bool animating;

    public void AnimateTo(float target)
    {
        startScale = transform.localScale ;
        targetScale = target;
        elapsed = 0f;
        animating = true;
    }

    void Update()
    {
        if (!animating) return;

        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / duration);
        float eased = Mathf.Sin(t * Mathf.PI * 0.5f);

        transform.localScale = Vector3.Lerp(startScale, Vector3.one * targetScale  *  2, eased);

        if (t >= 1f)
            animating = false;
    }
}
