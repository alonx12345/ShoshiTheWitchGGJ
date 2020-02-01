using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventroy : MonoBehaviour
{
    [SerializeField] public Transform[] slotPoses = null;
    [SerializeField] GameObject inventoryUI;
    public bool wandRepaired = false;

    public bool InventoryOpen(){
        return inventoryUI.activeInHierarchy;
    }
}
