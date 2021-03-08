using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationUnit : MonoBehaviour
{
    public float HP => unit.HP;
    public string GunName => gun.name;
    public int GunAmmoNow => gun.nowAmmoInShop;
    public int GunAmmoMax => gun.maxAmmoInShop;
    public int AmmoTypeNow => ammoController.ammo[gun.typeAmmo].nowAmmo;

    UnitBehvarion unit;
    Gun gun;
    AmmoController ammoController;

    public InformationUnit(UnitBehvarion unit)
    {
        gun = unit.weaponController.GetGun;
        ammoController = unit.weaponController.GetAmmoController;
    }

}
