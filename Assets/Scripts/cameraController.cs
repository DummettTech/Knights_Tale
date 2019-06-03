using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float cameraMoveSpeed = 100.0f;
    public GameObject CameraFollowObj;
    Vector3 followPosition;
    public float clamAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject playerObject;
    public float camDistanceXToPlayer;
    public float camDistanceZToPlayer;
    public float camDistanceYToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    // in future will be better to get attempt to get via tag and handle if none found

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;
        Debug.Log(inputX);
        rotX = Mathf.Clamp(rotX, -clamAngle, clamAngle);

        Quaternion localRotaion = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotaion;

    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        Transform target = CameraFollowObj.transform;

        float step = cameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
