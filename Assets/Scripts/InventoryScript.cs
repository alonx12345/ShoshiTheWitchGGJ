using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{

    [SerializeField] GameObject Inventory = null;
    [SerializeField] Slots[] slots = null;
    [HideInInspector] public bool isFull = false;

    List<Item> itemsInventory = new List<Item>();
    InventoryScript instance;
    int inventoryIndex = 0;
    void Start()
    {
        instance = this;
        Reset();
        
    }

    private void Reset() {

    }

    void Update()
    {
    }

    public void AddToInventory(Item addedItem, Sprite sprite) {
        if (inventoryIndex > slots.Length - 1) {
            Debug.Log("Inventory Full");
            isFull = true;
            return;
        }
        itemsInventory.Add(addedItem);
        slots[inventoryIndex].SetItemToSlot(addedItem, sprite);
        //slots[inventoryIndex].GetComponentInChildren<Image>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
        //slots[inventoryIndex].gameObject.SetActive(true);
        //slots[]
        inventoryIndex++;
    }
}
