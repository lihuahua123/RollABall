using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent navMeshAgent;
    private Rigidbody m_player;
    public Rigidbody penicillin;
    public float moveDistance=0.5f;
    private Vector3 last;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //先在Start()函数中获得玩家的组件：
        m_player = GameObject.FindGameObjectWithTag("baterial").GetComponent<Rigidbody>();
        penicillin= GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        Vector3 penicillinPosition = penicillin.transform.position;
        last = penicillinPosition;

    }

    // Update is called once per frame
    void Update()
    {

        //将自动寻路的目标设置为玩家所在位置
        GetComponent<NavMeshAgent>().destination = m_player.transform.position;
        Vector3 myPosition = transform.localPosition;
        Vector3 penicillinPosition= penicillin.transform.position;
        float distance=Vector3.Distance(myPosition, penicillinPosition);
        
        if (distance < moveDistance)
        {
            Vector3 uiPos = myPosition;
            float ix = (last.x - penicillinPosition.x) > 0 ? -1 : 1;
            float iy = (last.y - penicillinPosition.y) > 0 ? -1 : 1;
            uiPos.x = penicillinPosition.x+ ix*moveDistance;

            uiPos.y = penicillinPosition.y + iy*moveDistance;

            transform.localPosition = uiPos;

        }
        last = penicillinPosition;


    }
}
