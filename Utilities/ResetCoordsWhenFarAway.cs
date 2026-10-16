using UnityEngine;

public class ResetCoordsWhenFarAway : MonoBehaviour
{
    public Transform target;
    public float range = 100.0f;
    public Vector3 pos;
    public Quaternion rot;
    void Start()
    {
        pos = transform.position;
        rot = transform.rotation;
    }

    void Update()
    {
        if (target == null) return;
        if (Vector3.Distance(target.position,transform.position) > range)
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }
}
