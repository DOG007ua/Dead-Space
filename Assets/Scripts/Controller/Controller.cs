using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller : MonoBehaviour
{
    public UnitBehvarion selectUnit;
    public GameObject selectUnitCopy;
    public Material selectMaterial;
    private bool isNewPosition = false;
    ControllerCamera controllerCamera;

    void Start()
    {
        controllerCamera = GetComponent<ControllerCamera>();
        controllerCamera.Initialization(-25, 25, 10, -20);
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        MouseMove();
        if (Input.GetMouseButtonDown(0))
        {
            LeftMouseDown();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RigthMouseDown();
        }
    }

    private void MouseMove()
    {
        
    }

    private void LeftMouseDown()
    {
        var gameObjectClick = GORay();
        if(gameObjectClick != null)
        {
            SelectUnit(gameObjectClick);
        }
    }

    private void RigthMouseDown()
    {
        if (selectUnit != null)
        {
            MoveUnit(selectUnit, GOPosition());
        }
    }

    private GameObject GORay()
    {
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            
        }
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
            //position = hit.point + new Vector3(0, 1, 0);
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
    }

    void CreateCopySelectUnit(GameObject originalGO)
    {
        if (selectUnitCopy != null) Destroy(selectUnitCopy);

        selectUnitCopy = new GameObject("Copy Parent");
        selectUnitCopy.transform.position = originalGO.transform.position;

        var components = originalGO.GetComponentsInChildren<MeshRenderer>();
        foreach (var com in components)
        {
            CreateMesh(com.transform, selectUnitCopy.transform);
        }

        var copyMove = selectUnitCopy.AddComponent<CopyMove>();
        copyMove.Initialized(selectMaterial, originalGO);
    }

    private void CreateMesh(Transform obj, Transform parent)
    {
        var copyObject = new GameObject(obj.name + " Copy");
        copyObject.transform.SetParent(parent);
        var meshCopy = copyObject.AddComponent<MeshRenderer>();
        var meshFilterCopy = copyObject.AddComponent<MeshFilter>();
        meshCopy.material = obj.GetComponent<MeshRenderer>().material;
        meshCopy.material = selectMaterial;
        meshFilterCopy.mesh = obj.GetComponent<MeshFilter>().mesh;
        copyObject.transform.position = obj.transform.position;
        copyObject.transform.rotation = obj.transform.rotation;
        copyObject.transform.localScale = obj.transform.localScale;
    }

    private void MoveUnit(UnitBehvarion unit, Vector3 position)
    {
        if(isNewPosition)
        {
            unit.controllerMove.PositionMove = position;
            isNewPosition = false;
        }        
    }

}
