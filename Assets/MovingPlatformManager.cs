using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformManager : MonoBehaviour
{
    public float moveFor;
    public float speed;
    public Vector3 offset;

    private float startX = 0;

    private void Start()
    {
        transform.position += offset;
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x > startX + moveFor && speed > 0) || (transform.position.x < startX - moveFor && speed < 0))
        {
            speed *= -1;
        }

        Vector3 move = new Vector3(speed*Time.deltaTime, 0, 0);
        transform.position += move;

    }
}
