using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //카메라 오브젝트 따라 움직이기 1번
    public Transform target;
    public float distance = 8.0f;
    public float height = 1.0f;
    public float smoothRotate = 5.0f;

    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        float curYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y,
            smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, curYAngle, 0);

        tr.position = target.position - (rot * Vector3.forward * distance)
             + (Vector3.up * height);

        tr.LookAt(target);
    }

}

