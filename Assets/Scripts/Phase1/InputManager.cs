using UnityEngine;

public class InputManager : MonoBehaviour
{
    public BoxAnimator redBox;
    public BoxAnimator greenBox;
    public BoxAnimator blueBox;
    public BoxAnimator yellowBox;

    public CharacterController redBoxCharacter;
    public CharacterController greenBoxCharacter;
    public CharacterController blueBoxCharacter;
    public CharacterController yellowBoxCharacter;


    float normalScale = 450;
    float maxPercent = 0.75f;
    float minPercent = 0.25f;

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

        largeScale = new Vector2(normalScale * maxPercent, normalScale * maxPercent);
        sideScale = new Vector2(normalScale * minPercent, normalScale * maxPercent);
        bottomScale = new Vector2(normalScale * maxPercent, normalScale * minPercent);
        cornerScale = new Vector2(normalScale * minPercent, normalScale * minPercent);


        switch (target)
        {
            case BoxAnimator b when b == redBox:
                redBox.AnimateTo(largeScale);
                greenBox.AnimateTo(sideScale);
                blueBox.AnimateTo(bottomScale);
                yellowBox.AnimateTo(cornerScale);

                redBoxCharacter.AnimateTo(maxPercent);
                greenBoxCharacter.AnimateTo(minPercent);
                blueBoxCharacter.AnimateTo(minPercent);
                yellowBoxCharacter.AnimateTo(minPercent);

                break;

            case BoxAnimator b when b == greenBox:
                redBox.AnimateTo(sideScale);
                greenBox.AnimateTo(largeScale);
                blueBox.AnimateTo(cornerScale);
                yellowBox.AnimateTo(bottomScale);

                redBoxCharacter.AnimateTo(minPercent);
                greenBoxCharacter.AnimateTo(maxPercent);
                blueBoxCharacter.AnimateTo(minPercent);
                yellowBoxCharacter.AnimateTo(minPercent);
                break;

            case BoxAnimator b when b == blueBox:
                redBox.AnimateTo(bottomScale);
                greenBox.AnimateTo(cornerScale);
                blueBox.AnimateTo(largeScale);
                yellowBox.AnimateTo(sideScale);

                redBoxCharacter.AnimateTo(minPercent);
                greenBoxCharacter.AnimateTo(minPercent);
                blueBoxCharacter.AnimateTo(maxPercent);
                yellowBoxCharacter.AnimateTo(minPercent);
                break;

            case BoxAnimator b when b == yellowBox:
                redBox.AnimateTo(cornerScale);
                greenBox.AnimateTo(bottomScale);
                blueBox.AnimateTo(sideScale);
                yellowBox.AnimateTo(largeScale);

                redBoxCharacter.AnimateTo(minPercent);
                greenBoxCharacter.AnimateTo(minPercent);
                blueBoxCharacter.AnimateTo(minPercent);
                yellowBoxCharacter.AnimateTo(maxPercent);
                break;
        }
    }
}
