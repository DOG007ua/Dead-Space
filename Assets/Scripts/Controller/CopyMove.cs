using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class CopyMove : MonoBehaviour
{
    private Material selectMaterial;
    private GameObject originalGO;
    private bool isNewPosition;
    private bool visible = true;

    void Start()
    {
        //GetComponent<Collider>().enabled = false;
        RecursionCopy(transform, selectMaterial);
    }

    public void Initialized(Material selectMaterial, GameObject originalGO)
    {
        this.selectMaterial = selectMaterial;
        this.originalGO = originalGO;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = GOPosition();
        if (isNewPosition) transform.position = pos;
        Orientation();
        Visible();
    }

    private Vector3 GOPosition()
    {
        Ray ray = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Vector3 position = Vector3.zero;
        isNewPosition = false;
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            isNewPosition = true;
            //position = hit.point + new Vector3(0, 1, 0);
            position = new Vector3(hit.point.x, 1, hit.point.z);
        }
        return position;
    }

    void RecursionCopy(Transform gameObject, Material material)
    {
        var mesh = gameObject.GetComponent<MeshRenderer>();
        if (mesh != null) mesh.material = material;

        var lineRender = gameObject.GetComponent<LineRenderer>();
        if (lineRender != null) lineRender.enabled = false;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var child = gameObject.transform.GetChild(i);
            RecursionCopy(child, material);
        }
    }

    void RecursionCopyVisible(Transform gameObject)
    {
        var mesh = gameObject.GetComponent<MeshRenderer>();
        if (mesh != null) mesh.enabled = visible;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var child = gameObject.transform.GetChild(i);
            RecursionCopyVisible(child);
        }
    }

    void Orientation()
    {
        //transform.LookAt(originalGO.transform.position);
    }

    private void Visible()
    {
        var minDistanceVisible = 1.5f;
        var distance = Vector3.Distance(originalGO.transform.position, transform.position);
        if (distance < minDistanceVisible && visible)
        {
            visible = false;
            RecursionCopyVisible(this.transform);
        }
        if(distance > minDistanceVisible && !visible)
        {
            visible = true;
            RecursionCopyVisible(this.transform);
        }
    }
}
