using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPosition : MonoBehaviour
{
    public GameObject Soldier;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var posGO = Camera.allCameras[0].WorldToScreenPoint(Soldier.transform.position + new Vector3(0, 1, 0));
        var posNeedX = -Screen.width / 2f + posGO.x;
        var posNeedY = -Screen.height / 2f + posGO.y;
        var rect = transform.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(posNeedX, posNeedY, 0);
    }
}
