using TMPro;
using UnityEngine;

public class TextPanelController : MonoBehaviour
{
    public RectTransform boxRect;
    public TextMeshProUGUI text;
    RectTransform panelRect;


    void Awake()
    {
        panelRect = GetComponent<RectTransform>();
    }

    void LateUpdate()
    {
        panelRect.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,
            boxRect.rect.width
        );
    }

    public void SetText(string id)
    {
        text.text = CSVReader.ReadCSV()[id];
    }

}
