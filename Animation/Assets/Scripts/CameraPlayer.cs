using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public GameObject FollowedObject;
    public Vector3 offset = new Vector3(0,0,0);

    // Update is called once per frame
    void Update()
    {
        if (FollowedObject != null)
        {
            this.transform.position = FollowedObject.transform.position + offset;
        }
    }
}
