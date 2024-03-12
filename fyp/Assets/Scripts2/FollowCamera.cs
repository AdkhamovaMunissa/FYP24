using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // [SerializeField] GameObject thingToFollow;
    // // this things position (camera) should be the same as the car's position

    // void LateUpdate()
    // {
    //     transform.position = thingToFollow.transform.position + new Vector3 (0,0,-10);
    // }

    [SerializeField] private GameObject thingToFollow;
    [SerializeField] private GameObject minXAndYObject;
    [SerializeField] private GameObject maxXAndYObject;

    public Vector2 minXAndY;
    public Vector2 maxXAndY;

    private void Start()
    {
        minXAndY = minXAndYObject.transform.position;
        maxXAndY = maxXAndYObject.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = thingToFollow.transform.position + new Vector3(0, 0, -10);
        newPosition.x = Mathf.Clamp(newPosition.x, minXAndY.x, maxXAndY.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minXAndY.y, maxXAndY.y);

        transform.position = newPosition;
    }
}
