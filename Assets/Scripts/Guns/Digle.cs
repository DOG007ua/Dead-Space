using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digle : Pistols
{
    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        Execute();
    }

    public override void Initialize()
    {
        base.Initialize();
        typeAmmo = TypeAmmo.Pistol;
        Damage = 30;
        maxAmmoInShop = 7;
        nowAmmoInShop = maxAmmoInShop;
        timeReloadShop = 5;
        timeBetweenShoots = 0.8f;
        maxRange = 30;
        Dispersion = 10;
    }


    public override void Execute()
    {
        base.Execute();
    }
}
