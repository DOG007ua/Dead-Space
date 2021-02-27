//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    protected TypeAmmo typeAmmo;
    private Transform pointSpawnBullet;
    public int maxAmmoInShop;
    public int nowAmmoInShop;
    protected float timeReloadShop;
    protected float timeBetweenShoots;
    public float timeAfterShoot = 0;
    public float timeToReload = 0;
    public bool IsReload = false;
    public bool reloadBetweenShoot = false;
    public bool CanShoot = true;
    public float maxRange;
    public float Damage;
    public float Dispersion;
    public Action<TypeAmmo, int> eventReload;
    private WeaponController weaponController;

    public virtual void Initialize()
    {
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        for(int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.name == "Spawn")
            {
                pointSpawnBullet = child;
                break;
            }
        }
    }

    public virtual void Execute()
    {        
        FinishReload();
        IsReloadBetweenShoot();
        CanShoot = IsCanShoot();
    }

    protected bool IsCanShoot()
    {
        return !(IsReload || reloadBetweenShoot);
    }

    protected void IsReloadBetweenShoot()
    {
        if (!reloadBetweenShoot) return;
        
        timeAfterShoot += Time.deltaTime;
        if (timeAfterShoot > timeBetweenShoots)
        {
            timeAfterShoot = 0;
            reloadBetweenShoot = false;
        }
    }

    public void Reload()
    {
        if (nowAmmoInShop == maxAmmoInShop) return;
        timeToReload = timeReloadShop;
        IsReload = true;
    }

    public void FinishReload()
    {
        if (!IsReload) return;

        timeToReload -= Time.deltaTime;
        if(timeToReload < 0)
        {
            IsReload = false;
            var needAmmo = maxAmmoInShop - nowAmmoInShop;
            eventReload?.Invoke(typeAmmo, needAmmo);            
        }
    }

    public void SetAmmoAfterReloar(int value)
    {
        nowAmmoInShop += value;
    }

    public void Shoot(Vector3 positionShoot)
    {
        if (IsReload) return;
        if (nowAmmoInShop <= 0) return;

        nowAmmoInShop -= 1;
        SpawnBullet(positionShoot);
        reloadBetweenShoot = true;

        if (nowAmmoInShop <= 0) Reload();
    }

    public void SpawnBullet(Vector3 positionShoot)
    {
        var bullet = Instantiate(bulletPrefab);
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Initialize(Damage);

        bullet.transform.position = pointSpawnBullet.position;        
        var direction = -(pointSpawnBullet.position - positionShoot).normalized;
        bullet.transform.rotation = Quaternion.LookRotation(direction);
        CalculationDispersion(bullet);
    }

    private void CalculationDispersion(GameObject bullet)
    {
        var dispersionX = UnityEngine.Random.Range(0, Dispersion);
        var dispersionY = UnityEngine.Random.Range(0, Dispersion);
        bullet.transform.Rotate(dispersionX, dispersionY, 0);
    }
}

public enum TypeGun
{
    Digle,
    Glock,
    MP5,
    M16
}




