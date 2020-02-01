using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    UIscript UIscript = null;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        UIscript = FindObjectOfType<UIscript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            FlipInventory();
        }
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            FlipInventory();
            UIscript.FlipInventory();
        }
    }

    private void FlipInventory() {
        //gameObject.GetComponent<Animator>(). = true;
        animator.SetBool("open", !animator.GetBool("open"));
    }
}
