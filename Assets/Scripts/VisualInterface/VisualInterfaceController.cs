using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VisualInterfaceController : MonoBehaviour
{
    [SerializeField]private GameObject GunGameObject;
    private ViewerInterfaceGun viewerInterfaceGun;

    public void Initialize()
    {
        viewerInterfaceGun = new ViewerInterfaceGun(GunGameObject);
    }

    public void SetSelectUnit(UnitBehvarion unitBehvarion)
    {
        viewerInterfaceGun.SetSelectUnit(unitBehvarion.InformationUnit);
    }

    private void Update()
    {
        viewerInterfaceGun.Execute();
    }
}
