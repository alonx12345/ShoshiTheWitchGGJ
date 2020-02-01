using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    [SerializeField] GameObject DraggedObject;
    [SerializeField] Image image = null;

    private void Start() {
        
    }
    Item slotsItem = Item.Empty;
    public void OnClick() {

        //Debug.Log("Button pressed!");
        GameObject clone = Instantiate(DraggedObject);
        clone.GetComponent<InventoryDraggedObject>().CreateObject(slotsItem, image.sprite);
        image.gameObject.SetActive(false);
        
    }


    public void SetItemToSlot(Item item, Sprite sprite) {
        image.sprite = sprite;
        image.gameObject.SetActive(true);
        slotsItem = item;
    }
}
