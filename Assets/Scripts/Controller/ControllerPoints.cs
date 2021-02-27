using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPoints
{
    private static ControllerPoints instance;
    private static int points = 0;

    private ControllerPoints() 
    {
        points = 10000;
    }
    
    public static ControllerPoints Instance
    {
        get
        {
            if (instance == null)
                instance = new ControllerPoints();
            return instance;
        }
    }

    public int GetPoints => points;
    public bool SetPoints(int value)
    {
        var newValue = points + value;
        if (newValue >= 0)
        {
            points = newValue;
            return true;
        }            
        else
        {
            return false;
        }
    }
}
