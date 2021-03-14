using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UnitBehvarion : MonoBehaviour
{
    public float HP;
    
    public int ID;
    public bool isSelect;
    public WeaponController weaponController { get; private set; }
    public ControllerMove controllerMove { get; private set; }



    public SelectCircle selectCircle;
    public Action<UnitBehvarion> deadUnit;
    
    public bool canSelect = true;

    public UnitBehvarion Target
    {
        get => selectTarget.Target;
        set => selectTarget.Target = value;
    }    
    
    private ObjectsInRange objectsInRange;
    private SelectTarget selectTarget;

    

    public UnitBehvarion GetUnitBehvarion()
    {
        return this;
    }

    private void InitializationControlerMove()
    {
        controllerMove = new ControllerMove(this.transform, selectTarget);
    }

    private void InitializationSelectionTarget(string[] massNeedTagTarget)
    {      
        selectTarget = new SelectTarget(objectsInRange.listObject, massNeedTagTarget, this.gameObject);
        objectsInRange.eventAddObjectInRange += selectTarget.AddObjectInRange;
        objectsInRange.eventRemoveObjectInRange += selectTarget.RemoveObjectInRange;
    }

    private void InitializeWeaponController()
    {
        weaponController = GetComponentInChildren<WeaponController>();
        if (weaponController == null) return;
        selectTarget.newTarget += weaponController.SetTarget;
    }

    public void Initialization(GameObject gameObject, string[] massNeedTagTarget)
    {
        selectCircle = new SelectCircle(gameObject);
        objectsInRange = gameObject.transform.Find("RangeUnits").GetComponent<ObjectsInRange>();
        
        InitializationSelectionTarget(massNeedTagTarget);
        InitializationControlerMove(); 
        InitializeWeaponController();
    }

    public void Execute()
    {
        selectCircle.Execute();
        controllerMove.Execute();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected void MouseDown()
    {

    }

    public void Select(bool select)
    {
        if(canSelect)
        {
            isSelect = select;
            selectCircle.ActiveLineCircle(select);
        }        
    }

    

    public void Dead()
    {
        deadUnit?.Invoke(this);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Dead();
    }

    public void Damage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Dead();
        }
    }    
}
