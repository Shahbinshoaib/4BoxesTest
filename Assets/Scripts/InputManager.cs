using UnityEngine;

public class InputManager : MonoBehaviour
{
    public BoxAnimator redBox;
    public BoxAnimator greenBox;
    public BoxAnimator blueBox;
    public BoxAnimator yellowBox;

    float focusedScale = 352;
    float normalScale = 220;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Focus(redBox);
        if (Input.GetKeyDown(KeyCode.G)) Focus(greenBox);
        if (Input.GetKeyDown(KeyCode.B)) Focus(blueBox);
        if (Input.GetKeyDown(KeyCode.Y)) Focus(yellowBox);
    }

    void Focus(BoxAnimator target)
    {
        redBox.AnimateTo(target == redBox ? focusedScale : normalScale);
        greenBox.AnimateTo(target == greenBox ? focusedScale : normalScale);
        blueBox.AnimateTo(target == blueBox ? focusedScale : normalScale);
        yellowBox.AnimateTo(target == yellowBox ? focusedScale : normalScale);
    }
}
