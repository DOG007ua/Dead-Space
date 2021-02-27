using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCircle
{
    private LineRenderer circleRender;
    private GameObject gameObject;
    float radius = 1.1f;
    int amountPoints = 360;
    float anglePoint;
    
    public SelectCircle(GameObject gameObject)
    {
        circleRender = gameObject.transform.Find("CircleSelect")?.GetComponent<LineRenderer>() ?? null;
        if(circleRender == null)
        {
            Debug.Log($"Нет CircleSelect у {gameObject.name}");
            return;
        }
        this.gameObject = gameObject;
        anglePoint = 360.0f / amountPoints;
        circleRender.positionCount = amountPoints + 1;
    }

    public void Execute()
    {
        if (circleRender == null || !circleRender.enabled) return;
        CalculationCircle();
    }

    private void CalculationCircle()
    {
        var positionCenter = gameObject.transform.position;
        
        int amountPoints = 360;
        float anglePoint = 360.0f / amountPoints;
        circleRender.positionCount = amountPoints + 1;

        for (int i = 0; i <= amountPoints; i++)
        {
            var angle = i * anglePoint;
            var x = positionCenter.x + radius * Math.Sin(ConvertAngleToRad(angle));
            var z = positionCenter.z + radius * Math.Cos(ConvertAngleToRad(angle));
            circleRender.SetPosition(i, new Vector3((float)x, gameObject.transform.position.y, (float)z));
        }
    }

    private float ConvertAngleToRad(float value)
    {
        return value * 3.141592f / 180.0f;
    }

    public void ActiveLineCircle(bool active)
    {
        circleRender.enabled = active;
    }
}
