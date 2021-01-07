using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public readonly float coinScore = 50f;
    public float rotationSpeed;
    public Vector3 offset = new Vector3(0f, 2.5f, 0f);

    private void Start()
    {
        transform.position += offset;
    }
    // Update is called once per frame
    void Update()
    {
        //Rotate
        transform.Rotate(0, 0, rotationSpeed*Time.deltaTime);
    }
}
