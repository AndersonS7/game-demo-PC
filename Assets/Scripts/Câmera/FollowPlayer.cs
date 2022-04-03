using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Range(0.05f, 1)]
    [SerializeField] private float smoothTime;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    void FixedUpdate()
    {
        if (target != null)
        {
            CameraToPlayer();
        }
    }

    private void CameraToPlayer()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
        }
    }
}
