using UnityEngine;

public class BouncingCircle : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [Header("Scale Animation")]
    [SerializeField] private float scaleSpeed = 2f;
    [SerializeField] private float minScale = 0.85f;
    [SerializeField] private float maxScale = 1.15f;

    private Vector2 direction = Vector2.one.normalized;
    private SpriteRenderer spriteRenderer;
    private Camera cam;
    private float scaleTime;

    void Awake()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // SCALE ANIMATION
        scaleTime += Time.deltaTime * scaleSpeed;
        float t = (Mathf.Sin(scaleTime) + 1f) * 0.5f;
        float scale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = new Vector3(scale, scale, 1f);

        // MOVE
        Vector3 pos = transform.position;
        pos += (Vector3)(direction * speed * Time.deltaTime);

        // SCREEN BOUNDS (Viewport based)
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        float radiusX = spriteRenderer.bounds.extents.x;
        float radiusY = spriteRenderer.bounds.extents.y;

        // Horizontal bounce
        if (pos.x - radiusX < bottomLeft.x)
        {
            pos.x = bottomLeft.x + radiusX;
            direction.x *= -1;
        }
        else if (pos.x + radiusX > topRight.x)
        {
            pos.x = topRight.x - radiusX;
            direction.x *= -1;
        }

        // Vertical bounce
        if (pos.y - radiusY < bottomLeft.y)
        {
            pos.y = bottomLeft.y + radiusY;
            direction.y *= -1;
        }
        else if (pos.y + radiusY > topRight.y)
        {
            pos.y = topRight.y - radiusY;
            direction.y *= -1;
        }

        transform.position = pos;
    }
}
