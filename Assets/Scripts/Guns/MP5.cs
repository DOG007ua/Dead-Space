using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP5 : MachinePistol
{    private void Start()
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
        Damage = 10;
        maxAmmoInShop = 30;
        nowAmmoInShop = maxAmmoInShop;
        timeReloadShop = 4;
        timeBetweenShoots = 0.15f;
        maxRange = 35;
        Dispersion = 9;
    }


    public override void Execute()
    {
        base.Execute();
    }
}
