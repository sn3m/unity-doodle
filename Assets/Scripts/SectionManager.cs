using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject platformPrefab;
    // Start is called before the first frame update
    void Start()
    {
        GameObject newPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        newPlatform.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (-levelManager.speed * Time.deltaTime));
    }
}
