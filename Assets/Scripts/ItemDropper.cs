using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.EventSystems;

public class ItemDropper : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject itemPrefab = null;
    [SerializeField] GameObject placeToPut;
    [SerializeField] Vector2 dragSize = Vector2.zero;

    public bool Selected = false;
    bool rightCollide = false;
    bool snap = false;
    bool isSnapped = false;
    GameObject slotPos;
    private Vector3 MouseVector;
    Inventroy inventroy;
    Transform[] slotPoses;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Vector2 scale;
    Vector2 posOnClick;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        inventroy = FindObjectOfType<Inventroy>();
        slotPoses = inventroy.slotPoses;
        spriteRenderer = GetComponent<SpriteRenderer>();
        scale = transform.localScale;
    }

    void Update()
    {
        MouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Selected) {
            isSnapped = false;
            /* if (slotPos != null) {
                 slotPos.GetComponent<SlotHolder>().occupied = false;
             }*/
            spriteRenderer.sortingLayerName = "DraggedObjects";
            MouseUpdate();
            if (dragSize != Vector2.zero) {
                transform.localScale = dragSize;
            }
            posOnClick = transform.position;
        }
        else if (!Selected && isSnapped){
            spriteRenderer.sortingLayerName = "DraggedObjects";
            if (dragSize != Vector2.zero) {
                transform.localScale = dragSize;
            }
        }
        else {
            spriteRenderer.sortingOrder = 0;
            transform.localScale = scale;
        }
      /*  if (Selected && isSnapped) {
            //slotPos.GetComponent<SlotHolder>().occupied = false;
        }*/
        if (placeToPut != null && GetComponent<Collider2D>().IsTouching(placeToPut.GetComponent<Collider2D>())){
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            rightCollide = true;
        }
        else {
            rigid.constraints = RigidbodyConstraints2D.None;
        }
        Snap();

    }

    public void MouseUpdate() {
        gameObject.transform.position = MouseVector.x*Vector3.right + MouseVector.y*Vector3.up + gameObject.transform.position.z*Vector3.forward;
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            transform.parent = null;
            Selected = true;
        }
    }

    private void OnMouseUp() {
        Selected = false;
        if (rightCollide){
            placeToPut.GetComponent<RepairPlace>().ResetColor();
        }

        if (snap == true) {
            transform.parent = slotPos.transform;
            transform.position = slotPos.transform.position;
            isSnapped = true;
            //slotPos.GetComponent<SlotHolder>().occupied = true;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(itemPrefab);
        itemPrefab.GetComponent<ItemDropper>().Selected = true;
        Destroy(gameObject);
       // Selected = true;
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject == placeToPut){
    //         rightCollide = true;
    //     }
    // }

    private void OnCollisionExit(Collision other) {
        rightCollide = false;
    }
    

    void Snap(){
        if (!inventroy.InventoryOpen()){
            return;
        }

        foreach (Transform slot in slotPoses){
            if (Mathf.Abs(gameObject.transform.position.x - slot.position.x) <= 0.8f && Mathf.Abs(gameObject.transform.position.y - slot.position.y) <= 0.8f){
                if (slot.GetComponent<SlotHolder>().occupied) {
                    transform.position = posOnClick;
                    print("aaaa");
                    return;
                }
                snap = true;
                slotPos = slot.gameObject;
                rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                return;
            }
        }
        if (!rightCollide) {
            rigid.constraints = RigidbodyConstraints2D.None;
        }
        snap = false;
    }

    public void CancelAnimator(){
        Animator anim = GetComponent<Animator>();
        if (anim != null){
            Destroy(anim);
        }
    }
}
