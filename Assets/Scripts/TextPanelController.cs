using TMPro;
using UnityEngine;

public class TextPanelController : MonoBehaviour
{
    public RectTransform boxRect;
    public TextMeshProUGUI text;
    RectTransform panelRect;
    public string id;


    void Awake()
    {
        panelRect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        SetText(id);
    }

    public void SetText(string id)
    {
        var data = CSVReader.ReadCSV();

        Debug.Log("Looking for ID: " + id);

        if (data.TryGetValue(id, out string value))
        {
            text.text = value;
        }
        else
        {
            Debug.LogError("ID not found: " + id);
            text.text = "";
        }
    }


}
