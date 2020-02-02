using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
         GameObject player;

        // Use this for initialization
        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }


        // Update is called once per frame
        private void Update()
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,gameObject.transform.position.z);
        }
    }
}
