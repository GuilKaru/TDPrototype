using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    [Header("Towers UI")]
    public TowersShopBP cylindricTurret;
    public TowersShopBP prismTurret;
    public TowersShopBP pillTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseCylindricTower()
    {
        buildManager.SetTowerToBuild(cylindricTurret);
    }
    
    public void PurchasePrismTower()
    {
        buildManager.SetTowerToBuild(prismTurret);
    }
    
    public void PurchasePillTower()
    {
        buildManager.SetTowerToBuild(pillTurret);
    }
}
