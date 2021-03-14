using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewerInterfaceGun : IVisualInterface
{
    private InformationUnit informationUnit;
    private VisualObjectData dataAmmoNow;
    private VisualObjectData dataAmmoMax;
    private VisualObjectData dataGunName;
    private List<VisualObjectData> listObjectData = new List<VisualObjectData>();
    private bool isVisible = false;

    public bool IsVisible 
    { 
        get
        {
            return isVisible;
        }
        set
        {
            isVisible = value;
            SetVisible(value);
        }
    }

    public ViewerInterfaceGun(GameObject parent)
    {
        SetTextObjects(parent);
        IsVisible = false;
    }

    public void Execute()
    {
        if (!IsVisible) return;

        SetTextAmmoMax();
        SetTextAmmoNow();
        SetTextGunName();   
    }

    private void SetTextAmmoMax()
    {
        if(informationUnit.GunAmmoNow == 0) dataAmmoNow.text.color = Color.red;
        else dataAmmoNow.text.color = Color.white;

        dataAmmoNow.text.text = $"{informationUnit.GunAmmoNow}";
    }

    private void SetTextAmmoNow()
    {
        if (informationUnit.AmmoTypeNow == 0) dataAmmoMax.text.color = Color.red;
        else dataAmmoMax.text.color = Color.white;

        dataAmmoMax.text.text = informationUnit.AmmoTypeNow.ToString();
    }

    private void SetTextGunName()
    {
        dataGunName.text.text = informationUnit.GunName;
    }

    private void SetTextObjects(GameObject parent)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            var child = parent.transform.GetChild(i);
            switch (child.name)
            {
                case "AmmoNow":
                    {
                        dataAmmoNow = new VisualObjectData(child);
                        listObjectData.Add(dataAmmoNow);
                        break;
                    }
                case "AmmoAmunation":
                    {
                        dataAmmoMax = new VisualObjectData(child);
                        listObjectData.Add(dataAmmoMax);
                        break;
                    }
                case "GunName":
                    {
                        dataGunName = new VisualObjectData(child);
                        listObjectData.Add(dataGunName);
                        break;
                    }
            }
        }
    }

    public void SetSelectUnit(InformationUnit informationUnit)
    {
        this.informationUnit = informationUnit;
        if (informationUnit == null) IsVisible = false;
        else IsVisible = true;
    }

    private void SetVisible(bool value)
    {
        foreach (var obj in listObjectData)
        {
            obj.transformObject.gameObject.SetActive(value);
        }
    }

}
