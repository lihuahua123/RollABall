using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
       
       
    }

  
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,moveVertical);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(touchDeltaPosition.x * speed, 0f, touchDeltaPosition.y * speed);
        }
            rb.AddForce(movement*speed);

    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            ++count;
            if (count % 2==0) speed+=0.1f;
            SetCountText();
        }
    }
    private void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>=3)
        {
            winText.text="YOU WIN";
        }
    }

}
