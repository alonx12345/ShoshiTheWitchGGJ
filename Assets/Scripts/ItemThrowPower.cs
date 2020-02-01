using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemThrowPower : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float rotation;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(direction);
        rigid.AddTorque(rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
