using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    GameObject followtarget;
    private Vector3 offset = new Vector3(0f, 0f, -10f);

    public float smoothSpeed = 0.1f;

    void Start() {
        followtarget = GameObject.Find("Player");
    }


    void LateUpdate() {
        Vector3 desiredPosition = followtarget.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        gameObject.transform.position = smoothPosition;
    }
}
