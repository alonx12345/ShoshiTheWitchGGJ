using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class book : MonoBehaviour
{
    [SerializeField] GameObject rec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        rec.SetActive(true);
    }
    
    private void OnMouseExit() {
        rec.SetActive(false);
    }
}
