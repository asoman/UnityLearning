using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{


    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitiveHor = 3.0f;
    public float sensitiveVert = 3.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float _rotationX = 0;
    private float _rotationY = 0;


    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        switch (axes)
        {
            case RotationAxes.MouseXAndY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitiveVert;
                _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

                float delta = Input.GetAxis("Mouse X") * sensitiveHor;
                _rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
                break;
            case RotationAxes.MouseX:
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitiveHor, 0);
                break;
            case RotationAxes.MouseY:
                _rotationX -= Input.GetAxis("Mouse Y") * sensitiveVert;
                _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                break;
        }

    }
}
