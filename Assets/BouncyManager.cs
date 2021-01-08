using UnityEngine;

public class BouncyManager : MonoBehaviour
{
    public float forceMultipyler = 1.5f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position += offset;
    }
}
