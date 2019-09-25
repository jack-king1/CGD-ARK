using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{

        [Range(1.0f, 3.0f)]
        public float speed;
        private Rigidbody2D rigid;        

        // Use this for initialization
        void Start()
        {

            rigid = GetComponent<Rigidbody2D>();
        }


        void FixedUpdate()
        {

            float moveHorizontal = Input.GetAxis("Horizontal");


            float moveVertical = Input.GetAxis("Vertical");


            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rigid.AddForce(movement * speed);
        }

}
