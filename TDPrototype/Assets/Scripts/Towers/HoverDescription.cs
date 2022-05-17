using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum TowerType { Cylinder, Pill, Prism };
public class HoverDescription : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Tower Images")]
    [SerializeField] private Image CylinderDescription;
    [SerializeField] private Image PillDescription;
    [SerializeField] private Image PrismDescription;

    [Header("Tower Text")]
    [SerializeField] private GameObject CylinderText;
    [SerializeField] private GameObject PillText;
    [SerializeField] private GameObject PrismText;
    
    
    public TowerType towerType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("I entered");
        if(towerType == TowerType.Cylinder)
        {
            Debug.Log("I'm a Cylinder");
            CylinderDescription.color = Color.white;
            CylinderText.SetActive(true);
        }
        else if (towerType == TowerType.Pill)
        {
            Debug.Log("I'm a Pill");
            PillDescription.color = Color.white;
            PillText.SetActive(true);
        }
        else if (towerType == TowerType.Prism)
        {
            Debug.Log("I'm a Prism");
            PrismDescription.color = Color.white;
            PrismText.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CylinderDescription.color = Color.clear;
        CylinderText.SetActive(false);
        PillDescription.color = Color.clear;
        PillText.SetActive(false);
        PrismDescription.color = Color.clear;
        PrismText.SetActive(false);
    }
}
