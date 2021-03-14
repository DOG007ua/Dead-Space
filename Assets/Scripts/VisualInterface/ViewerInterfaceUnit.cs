using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerInterfaceUnit : IVisualInterface
{
    private InformationUnit informationUnit;
    private GameObject objectText;


    public bool IsVisible { get; set; } = true;

    public ViewerInterfaceUnit(InformationUnit informationUnit, GameObject objectText)
    {
        this.informationUnit = informationUnit;
        this.objectText = objectText;
    }

    public void Execute()
    {
        if (!IsVisible) return;
    }
}
