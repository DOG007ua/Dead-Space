using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControllerInput : MonoBehaviour
{
    IInputController inputController;

    public void Initialize(IInputController inputController)
    {
        this.inputController = inputController;
    }


    // Update is called once per frame
    void Update()
    {
        inputController.Execute();
    }    
}
