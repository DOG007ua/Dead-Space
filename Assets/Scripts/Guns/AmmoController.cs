using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController
{
    public Dictionary<TypeAmmo, AmmoParams> ammo = new Dictionary<TypeAmmo, AmmoParams>();

    public AmmoController()
    {
        ammo.Add(TypeAmmo.Pistol, new AmmoParams {maxAmmo = 100, nowAmmo = 10 });
        ammo.Add(TypeAmmo.Auto, new AmmoParams { maxAmmo = 200, nowAmmo = 45 });
    }

    public bool AddAmmo(TypeAmmo type, int value)
    {
        var ammoParams = ammo[type];
        if (ammoParams.maxAmmo == ammoParams.nowAmmo) return false;

        ammoParams.nowAmmo += value;
        if (ammoParams.maxAmmo < ammoParams.nowAmmo) ammoParams.nowAmmo = ammoParams.maxAmmo;

        return true;
    }

    public int RemoveAmmo(TypeAmmo type, int value)
    {
        var ammoParams = ammo[type];
        var returnAmmo = 0;
        if (value > ammoParams.nowAmmo) returnAmmo = ammoParams.nowAmmo;
        else returnAmmo = value;
        ammoParams.nowAmmo -= returnAmmo;

        return returnAmmo;
    }
}

public class AmmoParams
{
    public int maxAmmo;
    public int nowAmmo;
}

public enum TypeAmmo
{
    Pistol,
    Auto
}
