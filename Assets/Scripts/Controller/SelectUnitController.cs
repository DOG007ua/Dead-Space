using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitController
{
    public event Action<UnitBehvarion> eventSelectNewUnit;
    private UnitBehvarion selectUnit;
    private CopyUnitController copyUnitController;
    private bool isNewPosition = false;

    public void SelectClick()
    {
        var gameObjectClick = GORay();
        if (gameObjectClick != null)
        {
            SelectUnit(gameObjectClick);
        }
    }

    public void MoveUnit()
    {
        if (selectUnit != null)
        {
            MoveUnit(selectUnit, GOPosition());
        }
    }

    private GameObject GORay()
    {
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) { }
        if (hit.transform.gameObject.tag == "Terrain") return null;
        return hit.transform.gameObject;
    }

    private Vector3 GOPosition()
    {
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Vector3 position = Vector3.zero;

        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            position = new Vector3(hit.point.x, 1, hit.point.z);
            isNewPosition = true;
        }
        return position;
    }

    private void SelectUnit(GameObject go)
    {
        if (go.GetComponent<UnitBehvarion>() == null) return;
        var select = go.GetComponent<UnitBehvarion>();
        if (!select.canSelect) return;

        selectUnit?.Select(false);
        selectUnit = go.GetComponent<UnitBehvarion>();
        selectUnit.Select(true);
        CreateCopySelectUnit(go);

        eventSelectNewUnit?.Invoke(selectUnit);
    }

    void CreateCopySelectUnit(GameObject originalGO)
    {
        if (copyUnitController != null) copyUnitController.Destroy();


        copyUnitController = new CopyUnitController(originalGO, SettingsGame.Instance.settingsGameData.transperentMaterial, SettingsGame.Instance.settingsGameData.colorBlueTeam);
    }

    private void MoveUnit(UnitBehvarion unit, Vector3 position)
    {
        if (isNewPosition)
        {
            unit.controllerMove.PositionMove = position;
            isNewPosition = false;
        }
    }
}
