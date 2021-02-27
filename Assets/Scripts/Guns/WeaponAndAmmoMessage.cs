using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAndAmmoMessage
{
    public AmmoController ammoController;

    public WeaponAndAmmoMessage(AmmoController ammoController)
    {
        this.ammoController = ammoController;
    }

    public bool HaveAmmo(TypeAmmo typeAmmo) => ammoController.ammo[typeAmmo].nowAmmo > 0;
    public int RemoveAmmo(TypeAmmo type, int value) => ammoController.RemoveAmmo(type, value);
}
