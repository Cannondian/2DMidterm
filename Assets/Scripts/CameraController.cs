using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;

    public float followSpeed;

    public float xOffset = 0;
    public float yOffset = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera Follow Method 1 (Without move delay)
        //transform.position = new Vector3(target.position.x + xOffset, target.position.y + yOffset, transform.position.z);

        //Camera Follow Method 2 (With delay)
        float xTarget = target.position.x + xOffset;
        float yTarget = target.position.y + yOffset;

        float xNew  = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);

        
    }
}
