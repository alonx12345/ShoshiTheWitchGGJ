using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    InventoryScript InventoryScript = null;
    [SerializeField] Item itemType = Item.Empty;
    // Start is called before the first frame update
    void Start()
    {
        InventoryScript = FindObjectOfType<InventoryScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && !InventoryScript.isFull) {
            InventoryScript.AddToInventory(itemType, gameObject.GetComponentInChildren<SpriteRenderer>().sprite);
            Destroy(gameObject);
        }
    }


    
}
