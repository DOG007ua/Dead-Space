using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputInGame : IInputController
{
    SelectUnitController selectUnitController;

    public InputInGame(SelectUnitController selectUnitController)
    {
        this.selectUnitController = selectUnitController;
    }

    public bool isEnable { get; set; } = true;


    public void Initialize()
    {

    }

    public void Execute()
    {
        if (!isEnable) return;

        MouseClick();
    }

    private void MouseClick()
    {
        LeftMouseDown();
        RigthMouseDown();
    }

    private void LeftMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FirstTypeClick();
        }
    }


    private void RigthMouseDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SecondTypeClick();
        }
    }

    public void FirstTypeClick()
    {
        selectUnitController.SelectClick();
    }

    public void SecondTypeClick()
    {
        selectUnitController.MoveUnit();
    }

    
}
