using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerPlatform : MonoBehaviour
{
    [Header("Tower in Platform")]
    public GameObject tower;

    [Header("Platform Colors")]
    public Color hoverColor;
    public Color noMoneyHoverColor;

    private Renderer rend;
    private Color startColor;


    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if (!buildManager.HasMoney)
        {
            rend.material.color = noMoneyHoverColor;
        }
        else
        {
            rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (tower != null)
        {
            return;
        }

        buildManager.BuildTowerHere(this);

    }

    
}
