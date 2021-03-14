using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock : Pistols
{
    private void Start()
    {

    }

    private void Update()
    {
        Execute();
    }

    public override void Initialize(WeaponAndAmmoMessage weaponAndAmmoMessage)
    {
        base.Initialize(weaponAndAmmoMessage);
        nameGun = GetType().ToString();
        typeAmmo = TypeAmmo.Pistol;
        Damage = 15;
        maxAmmoInShop = 15;
        nowAmmoInShop = maxAmmoInShop;
        timeReloadShop = 2;
        timeBetweenShoots = 0.5f;
        maxRange = 30;
        Dispersion = 8;
    }


    public override void Execute()
    {
        base.Execute();
    }
}
