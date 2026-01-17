using UnityEngine;

public class InputManager : MonoBehaviour
{
    public BoxAnimator redBox;
    public BoxAnimator greenBox;
    public BoxAnimator blueBox;
    public BoxAnimator yellowBox;

    float normalScale = 450;

    Vector2 largeScale ;
    Vector2 sideScale ;
    Vector2 bottomScale ;
    Vector2 cornerScale ;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Focus(redBox);
        if (Input.GetKeyDown(KeyCode.G)) Focus(greenBox);
        if (Input.GetKeyDown(KeyCode.B)) Focus(blueBox);
        if (Input.GetKeyDown(KeyCode.Y)) Focus(yellowBox);
    }

    void Focus(BoxAnimator target)
    {

        largeScale = new Vector2(normalScale * 0.8f, normalScale * 0.8f);
        sideScale = new Vector2(normalScale * 0.2f, normalScale * 0.8f);
        bottomScale = new Vector2(normalScale * 0.8f, normalScale * 0.2f);
        cornerScale = new Vector2(normalScale * 0.2f, normalScale * 0.2f);


        switch (target)
        {
            case BoxAnimator b when b == redBox:
                redBox.AnimateTo(largeScale);
                greenBox.AnimateTo(sideScale);
                blueBox.AnimateTo(bottomScale);
                yellowBox.AnimateTo(cornerScale);
                break;

            case BoxAnimator b when b == greenBox:
                redBox.AnimateTo(sideScale);
                greenBox.AnimateTo(largeScale);
                blueBox.AnimateTo(cornerScale);
                yellowBox.AnimateTo(bottomScale);
                break;

            case BoxAnimator b when b == blueBox:
                redBox.AnimateTo(bottomScale);
                greenBox.AnimateTo(cornerScale);
                blueBox.AnimateTo(largeScale);
                yellowBox.AnimateTo(sideScale);
                break;

            case BoxAnimator b when b == yellowBox:
                redBox.AnimateTo(cornerScale);
                greenBox.AnimateTo(bottomScale);
                blueBox.AnimateTo(sideScale);
                yellowBox.AnimateTo(largeScale);
                break;
        }
    }
}
