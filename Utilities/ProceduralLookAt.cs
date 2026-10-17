using UnityEngine;

public class ProceduralLookAt : MonoBehaviour
{
    public Transform target;
    public float range = 10.0f;
    public float turnSpeed = 5.0f;
    void Update()
    {
        if (target != null && Vector3.Distance(target.position, transform.position) < range)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), Time.deltaTime * turnSpeed);
        }
    }
}
