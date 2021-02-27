using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enginer : Soldier
{

    private void Start()
    {
        Initialization(this.gameObject, new string[] { "Enemy" });
        HP = 100;
        MaxAmmo = 30;
        Speed = 5;
    }

    private void Update()
    {
        Execute();
        MouseDown();
        Move();
    }
}
