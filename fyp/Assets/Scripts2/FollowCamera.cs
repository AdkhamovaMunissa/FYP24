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
    // [SerializeField] private GameObject minXAndYObject;
    // [SerializeField] private GameObject maxXAndYObject;

    private Vector2 minCameraPos;  // Minimum position for the camera
    private Vector2 maxCameraPos;  // Maximum position for the camera
    private Camera mainCamera;


    public Vector2 minXAndY;
    public Vector2 maxXAndY;

    private void Start()
    {
        // minXAndY = minXAndYObject.transform.position;
        // maxXAndY = maxXAndYObject.transform.position;
        mainCamera = GetComponent<Camera>();

        minCameraPos = mainCamera.ViewportToWorldPoint(Vector2.zero);
        maxCameraPos = mainCamera.ViewportToWorldPoint(Vector2.one);

    }

    private void LateUpdate()
    {
        Vector3 newPosition = thingToFollow.transform.position + new Vector3(0, 0, -10);

        float clampedX = Mathf.Clamp(newPosition.x, minCameraPos.x, maxCameraPos.x);
        float clampedY = Mathf.Clamp(newPosition.y, minCameraPos.y, maxCameraPos.y);
        Vector3 clampedCameraPos = new Vector3(clampedX, clampedY, transform.position.z);

        transform.position = newPosition;
    }


}
