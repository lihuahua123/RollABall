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
    [SerializeField]
    private ETCJoystick joystick;//虚拟摇杆
    [SerializeField]
    private Rigidbody rig;

    [SerializeField]
    private float runSpeed = 2.0f;//移动速度
    [SerializeField]
    


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        joystick.onMoveEnd.AddListener(() => onMoveEnd());

        //方式一：按键方法注册
        joystick.OnPressLeft.AddListener(() => JoystickHandlerMoving());
        joystick.OnPressRight.AddListener(() => JoystickHandlerMoving());
        joystick.OnPressUp.AddListener(() => JoystickHandlerMoving());
        joystick.OnPressDown.AddListener(() => JoystickHandlerMoving());


    }

  
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,moveVertical);
            rb.AddForce(movement*speed);

        if (ETCInput.GetAxisPressedUp("Vertical"))
        {
            JoystickHandlerMoving();
        }


        if (ETCInput.GetAxisPressedDown("Vertical"))
        {
            JoystickHandlerMoving();
        }


        if (ETCInput.GetAxisPressedLeft("Horizontal"))
        {
            JoystickHandlerMoving();

        }
        if (ETCInput.GetAxisPressedRight("Horizontal"))
        {
            JoystickHandlerMoving();

        }


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
       
    }
    void onMoveEnd()
    {
        
        rig.velocity = Vector3.zero;
    }



    void JoystickHandlerMoving()
    {
        if (joystick.name != "New Joystick")
        {
            return;
        }

        //获取虚拟摇杆偏移量  
        float h = joystick.axisX.axisValue;
        float v = joystick.axisY.axisValue;

        if (Mathf.Abs(h) > 0.05f || (Mathf.Abs(v) > 0.05f))
        {
            Quaternion rota = transform.rotation;
            Quaternion finl = Quaternion.LookRotation(new Vector3(h, 0, v));
            transform.rotation = Quaternion.LerpUnclamped(rota, finl, 0.5f);
            rig.velocity = new Vector3(h * runSpeed, rig.velocity.y, v * runSpeed);
            
        }
        else
        {
            
        }
    }

}
