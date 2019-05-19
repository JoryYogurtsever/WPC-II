using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
        public GameObject target;
        public bool followTarget;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(followTarget)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -1);
        }
    }
}
