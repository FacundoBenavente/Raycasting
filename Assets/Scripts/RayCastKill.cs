using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastKill : MonoBehaviour
{
    [SerializeField] Transform originTR;
    [SerializeField] float rayLength;
    public string raycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(originTR.position, originTR.forward, out hitInfo, rayLength))
        {
            raycastHit = hitInfo.collider.name;
        }

    }


    private void OnDrawGizmos()
    {
        Color color = Color.green;
        Gizmos.color = color;
        Gizmos.DrawLine(originTR.position, originTR.position + originTR.forward * rayLength);
    }
}


