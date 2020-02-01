using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour {

    public int rotationOffset = 90;
    public bool flip = false;
    // Update is called once per frame
    void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
      //  if (rotZ >= 90 || rotZ <= -90) {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
            //  Vector3 theScale = transform.localScal0e;
            // theScale.x *= -1;
            // transform.localScale = theScale;
        //}
      //  else {
         //   transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        //}
    }
}  
