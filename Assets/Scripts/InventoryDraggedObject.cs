using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDraggedObject : MonoBehaviour
{
    Item draggedObjItem;
    // Update is called once per frame
    void Update()
    {
        Vector3 MouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = MouseVector.x * Vector3.right + MouseVector.y * Vector3.up + gameObject.transform.position.z * Vector3.forward;
    }

    public void CreateObject(Item item, Sprite sprite) {
        draggedObjItem = item;
        GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.SetActive(true);

    }

    private void OnMouseUp() {
        
    }
}
