using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // This thing position (camera) should match the car's position
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
    }
}
