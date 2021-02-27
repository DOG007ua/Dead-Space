using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Gun MainGun;
    private GameObject gamObjectMainGun;
    private UnitBehvarion target;
    private UnitBehvarion player;
    private AmmoController ammoController;
    private WeaponAndAmmoMessage weaponAndAmmoMessage;


    void Start()
    {
        player = transform.parent.GetComponent<UnitBehvarion>();
        MainGun = GetComponentInChildren<Gun>();
        gamObjectMainGun = MainGun.gameObject;
        ammoController = new AmmoController();
        weaponAndAmmoMessage = new WeaponAndAmmoMessage(ammoController);
        SetMainGun(TypeGun.Digle);
    }

    void Update()
    {
        Shooting();
        KeysController();
    }

    public void SetMainGun(TypeGun newGun)
    {
        Destroy(MainGun);
        switch(newGun)
        {
            case TypeGun.Digle:
                MainGun = gamObjectMainGun.AddComponent<Digle>();                
                break;
            case TypeGun.Glock:
                MainGun = gamObjectMainGun.AddComponent<Glock>();
                break;
            case TypeGun.MP5:
                MainGun = gamObjectMainGun.AddComponent<MP5>();
                break;
            default:
                MainGun = gamObjectMainGun.AddComponent<Glock>();
                break;
        }
        MainGun.Initialize(weaponAndAmmoMessage);
    }

    private void Shooting()
    {
        if (player.NeedMove || target == null) return;

        var distanceTarget = Vector3.Distance(player.transform.position, target.transform.position);
        if (distanceTarget < MainGun.maxRange && MainGun.CanShoot)
        {
            MainGun.Shoot(target.transform.position);
        }
    }

    public void SetTarget(UnitBehvarion newTarget)
    {
        target = newTarget;
    }

    public void Initialize(UnitBehvarion player)
    {
        this.player = player;
    }

    private void KeysController()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            MainGun.Reload();
        }
    }

    private void OnGUI()
    {
        if(MainGun.IsReload)
        {
            var positionText = player.transform.position + new Vector3(0, 2,0);
            var posInScreen = Camera.allCameras[0].WorldToScreenPoint(positionText);
            var time = Math.Round(MainGun.timeToReload, 1).ToString();
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(posInScreen.x, Screen.height - posInScreen.y, 80, 40), time);
        }        
    }


}
