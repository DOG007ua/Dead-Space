using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UnitBehvarion : MonoBehaviour
{
    public float HP;
    public float Speed;
    public int ID;
    public bool isSelect;
    public SelectCircle selectCircle;
    public Action<UnitBehvarion> deadUnit;
    public WeaponController weaponController { get; private set; }
    public bool canSelect = true;

    public UnitBehvarion Target
    {
        get => selectTarget.Target;
        set => selectTarget.Target = value;
    }

    protected Vector3 positionMove;
    public bool NeedMove { get; protected set; }
    private ObjectsInRange objectsInRange;
    private SelectTarget selectTarget;

    public Vector3 PositionMove
    {
        get { return positionMove; }
        set
        {
            positionMove = value;
            transform.LookAt(value);
            NeedMove = true;
        }
    }

    public UnitBehvarion GetUnitBehvarion()
    {
        return this;
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
        InitializeWeaponController();
    }

    public void Execute()
    {
        selectCircle.Execute();
        LookAtTarget();
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

    public void LookAtTarget()
    {
        if (Target != null && !NeedMove) transform.LookAt(Target.transform);
    }  

    protected void DeletePositionMove()
    {
        NeedMove = false;
    }

    protected void Move()
    {
        if (NeedMove)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
            var distance = Vector3.Distance(transform.position, positionMove);
            if(distance < 0.1f)
            {
                DeletePositionMove();
            }
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
