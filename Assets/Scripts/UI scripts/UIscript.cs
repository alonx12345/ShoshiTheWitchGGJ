using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIscript : MonoBehaviour
{

    Animator animator;
    Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startingPos = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            FlipInventory();
        }
    }

    public void FlipInventory() {
        //gameObject.GetComponent<Animator>(). = true;
        animator.SetBool("open", !animator.GetBool("open"));
    }
}
