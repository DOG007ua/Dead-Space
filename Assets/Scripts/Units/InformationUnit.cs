using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationUnit
{
    public float HP => unit.HP;
    public string GunName => gun.nameGun;
    public int GunAmmoNow => gun.nowAmmoInShop;
    public int GunAmmoMax => gun.maxAmmoInShop;
    public int AmmoTypeNow => ammoController.ammo[gun.typeAmmo].nowAmmo;

    UnitBehvarion unit;
    Gun gun;
    AmmoController ammoController;

    public InformationUnit(UnitBehvarion unit)
    {
        this.unit = unit; 
        gun = unit.weaponController?.GetGun;
        ammoController = unit.weaponController?.GetAmmoController;
    }

}
