using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Mini-Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    [Header("Towers Prefabs")]
    public GameObject CylindricTowerPrefab;
    public GameObject PrismTowerPrefab;
    public GameObject PillTowerPrefab;
    private TowersShopBP buildTower;
   
    public bool CanBuild 
    { 
        get 
        { 
            return buildTower != null; 
        } 
    }

    public bool HasMoney
    {
        get
        {
            return Stats.Money >= buildTower.cost;
        }
    }

    public void SetTowerToBuild(TowersShopBP turret)
    {
        buildTower = turret;
    }

    public void BuildTowerHere (TowerPlatform platform)
    {
        //Return if the player doesn't have enough money to build a tower
        if(Stats.Money < buildTower.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        //Build Tower and substract the cost to the Players Money.
        Stats.Money -= buildTower.cost;

        GameObject Tower = Instantiate(buildTower.TowerPrefab, platform.transform.position, platform.transform.rotation);
        Tower.transform.SetParent(platform.transform);
        platform.tower = Tower;

        Debug.Log($"Money Left: {Stats.Money}");
    }
}
