using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualObjectData
{
    public readonly RectTransform transform;
    public readonly Transform transformObject;
    public readonly Text text;

    public VisualObjectData(Transform gameObject)
    {
        this.transformObject = gameObject;
        text = gameObject.GetComponent<Text>();
        transform = gameObject.GetComponent<RectTransform>();
    }
}
