using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollide : MonoBehaviour
{
    [SerializeField] Collider2D[] collidersToTouch = null;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Item"){
           GetComponent<SpriteRenderer>().color = new  Color(254, 255, 0, 255);
       }
   }

   private void OnTriggerExit2D(Collider2D other) {
        GetComponent<SpriteRenderer>().color = color;
   }

   public void ResetColor(){
        GetComponent<SpriteRenderer>().color = color;
        CheckComplete();
   }

   public bool CheckComplete(){
       foreach (var collider in collidersToTouch){
           if (!GetComponent<Collider2D>().IsTouching(collider)){
               return false;
           }
       }
        print("AAAAAA");
       return true;
   }
    


}
