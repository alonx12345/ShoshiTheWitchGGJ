using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "cauldronItem") {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Cauldron/_cauldronDrop");
        }
    }
}
