using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyUnitController
{
    private GameObject gameObject;

    public GameObject GameObject => gameObject;

    public CopyUnitController(GameObject originalUnit, Material material, Color color)
    {
        var newMaterial = SetColorGameObject(material, color);
        Create(originalUnit, newMaterial);
    }

    private Material SetColorGameObject(Material material, Color color)
    {
        var materialCopy = GameObject.Instantiate(material);
        materialCopy.color = color;
        return materialCopy;
    }


    public void Create(GameObject originalUnit, Material material)
    {
        gameObject = new GameObject("Copy Parent");
        gameObject.transform.position = originalUnit.transform.position;

        var components = originalUnit.GetComponentsInChildren<MeshRenderer>();
        foreach (var com in components)
        {
            CreateMesh(com.transform, gameObject.transform, material);
        }

        var copyMove = gameObject.AddComponent<CopyMove>();
        copyMove.Initialized(material, originalUnit);
    }

    private void CreateMesh(Transform obj, Transform parent, Material material)
    {
        var copyObject = new GameObject(obj.name + " Copy");
        copyObject.transform.SetParent(parent);
        var meshCopy = copyObject.AddComponent<MeshRenderer>();
        var meshFilterCopy = copyObject.AddComponent<MeshFilter>();
        meshCopy.material = obj.GetComponent<MeshRenderer>().material;
        meshCopy.material = material;
        meshFilterCopy.mesh = obj.GetComponent<MeshFilter>().mesh;
        copyObject.transform.position = obj.transform.position;
        copyObject.transform.rotation = obj.transform.rotation;
        copyObject.transform.localScale = obj.transform.localScale;
    }

    public void Move()
    {        

    }

    public void Destroy()
    {
        GameObject.Destroy(GameObject);
    }
}
