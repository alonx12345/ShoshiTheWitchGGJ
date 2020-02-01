using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPlace : MonoBehaviour
{
    [SerializeField] Collider2D[] collidersToTouch = null;
    [SerializeField] GameObject repairedItem = null;
    [SerializeField] bool isTrigger = false;
    [SerializeField] string animBool = "cook";
    [SerializeField] Animator anim = null;
    [SerializeField] bool isWand = false;
    [SerializeField] GameObject wand1 = null;
    [SerializeField] GameObject wand2 = null;

    SpriteRenderer spriteRenderer;
    Color color;
    Inventroy inventroy;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventroy = FindObjectOfType<Inventroy>();
        if (spriteRenderer != null) {
            color = GetComponent<SpriteRenderer>().color;
        }
        
    }


   private void OnTriggerEnter2D(Collider2D other) {
        if ((spriteRenderer == null || !inventroy.wandRepaired) && !isWand) {
            return;
        }
        foreach (Collider2D collider in collidersToTouch){
           if (other.Equals(collider)){
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/FirstFloor/_repair");
                GetComponent<SpriteRenderer>().color = new  Color(254, 255, 0, 255);
           }
       }
   }

   private void OnTriggerExit2D(Collider2D other) {
        if ((spriteRenderer == null || !inventroy.wandRepaired) && !isWand) {
            return;
        }
        if (inventroy.wandRepaired || isWand)
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Shoshi/_Gesture");

        GetComponent<SpriteRenderer>().color = color;
        ;

   }


   public void ResetColor(){
        if ((spriteRenderer != null && inventroy.wandRepaired) || isWand) {
            GetComponent<SpriteRenderer>().color = color;
        }
        if (inventroy.wandRepaired || isWand)
            CheckComplete();
   }

   public void CheckComplete(){
       foreach (var collider in collidersToTouch){
           if (!GetComponent<Collider2D>().IsTouching(collider)){
               return ;
           }
        }
        foreach (var collider in collidersToTouch){
            Destroy(collider.gameObject);     
        }
        if (isTrigger) {
            anim.SetBool("cook", isTrigger);
        }
        /*else {
            if (spawnPoint != null) {
                Instantiate(repairedItem, spawnPoint.position, Quaternion.identity);
            }
            else {
                Instantiate(repairedItem);
            }
        }*/
        else {
            if (isWand) {
                inventroy.wandRepaired = true;
                wand1.SetActive(true);
                wand2.SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/FirstFloor/_magicRepair");
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Shoshi/_Giggle");
            }
            else {
                repairedItem.SetActive(true);
            }
        }
    }
    


}
