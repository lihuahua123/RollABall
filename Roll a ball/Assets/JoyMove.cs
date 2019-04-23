using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyMove : MonoBehaviour {

    
    [SerializeField]
    private ETCJoystick joystick;//虚拟摇杆
    [SerializeField]
    private Rigidbody rig;

    [SerializeField]
    private float runSpeed = 2.0f;//移动速度
    [SerializeField]
    private Animation anim;

    void Start()
    {

        joystick.onMoveEnd.AddListener(() => onMoveEnd());

        //方式一：按键方法注册
        joystick.OnPressLeft.AddListener(() => JoystickHandlerMoving());
        joystick.OnPressRight.AddListener(() => JoystickHandlerMoving());
        joystick.OnPressUp.AddListener(() => JoystickHandlerMoving());
        joystick.OnPressDown.AddListener(() => JoystickHandlerMoving());

    }

    //方式二：输入监测
    private void Update()//加个s为了取消运行
    {
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
    void onMoveEnd()
    {
        anim.Play("soldierIdleRelaxed");
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
            anim.Play("soldierRun");
        }
        else
        {
            anim.Play("soldierIdleRelaxed");
        }
    }

   
}
