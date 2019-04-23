using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject pickUp;
    private Vector3 offset;
    float times = 3000f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =  player.transform.position+offset;
        
        if (times < 0)
        {
            times = 3000f;
            for (int i = 0; i < 3; i++)
            {
                Instantiate(pickUp, new Vector3(Random.Range(-9f, 9f), 1, Random.Range(-9f, 9f)), Quaternion.identity);
            }
        }
        times -= 10f;
        
    }
}
