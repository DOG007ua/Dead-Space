using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInterface : MonoBehaviour
{    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2f, 20, 100, 50), ControllerPoints.Instance.GetPoints.ToString());
    }
}
