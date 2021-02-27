using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shop : MonoBehaviour
{
    UnitBehvarion unitInCollider;
    UnitBehvarion unitBuy;
    private bool needText = false;
    WeaponBuy weaponBuy = new WeaponBuy();

    public UnitBehvarion UnitBuy
    {
        get
        {
            return unitBuy;
        }
        set
        {
            unitBuy = value;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyControl();
    }

    private void KeyControl()
    {
        if(Input.GetKeyDown(KeyCode.F) && needText && unitInCollider.isSelect)
        {
            UnitBuy = unitInCollider;
            needText = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BlueTeam")
        {
            unitInCollider = other.transform.GetComponent<UnitBehvarion>();
            if (UnitBuy == null) needText = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlueTeam")
        {
            needText = false;
            UnitBuy = null;
        }
    }

    private void OnGUI()
    {
        if(needText)
        {
            GUI.Label(new Rect(Screen.width / 2f, Screen.height / 2f, 100, 50), "Press F if buy");
        }
        

        if(unitBuy != null)
        {
            if (GUI.Button(new Rect(0, Screen.height / 2f + 0 * 35, 70, 20), "Glock"))
            {
                Buy(TypeGun.Glock);
            }
            if (GUI.Button(new Rect(0, Screen.height / 2f + 1 * 35, 70, 20), "Digle"))
            {
                Buy(TypeGun.Digle);
            }
            if (GUI.Button(new Rect(0, Screen.height / 2f + 2 * 35, 70, 20), "MP-5"))
            {
                Buy(TypeGun.MP5);
            }
        }
    }

    private void Buy(TypeGun typeGun)
    {
        var weapon = weaponBuy[typeGun];
        if(ControllerPoints.Instance.SetPoints(-weapon.cost))
        {
            UnitBuy.weaponController.SetMainGun(typeGun);
        }
    }
}

public class WeaponBuy
{


    public WeaponTypeBuy this [TypeGun type]
    {
        get
        {
            return weaponTypeBuys.FirstOrDefault(v => v.typeGun == type);
        }
    }

    public List<WeaponTypeBuy> weaponTypeBuys = new List<WeaponTypeBuy>(new[]
    {
        new WeaponTypeBuy(){typeGun = TypeGun.Digle, cost = 100 },
        new WeaponTypeBuy(){typeGun = TypeGun.Digle, cost = 100 },
        new WeaponTypeBuy(){typeGun = TypeGun.MP5, cost = 500 },
        new WeaponTypeBuy(){typeGun = TypeGun.M16, cost = 1500 },
    });
}

public struct WeaponTypeBuy
{
    public TypeGun typeGun;
    public int cost;
}
