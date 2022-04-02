using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmInput : MonoBehaviour
{
    public GameObject WagBone;
    public GameObject CantBone;
    public float rotationZSpeed = 0.025f;
    private float rotationZ = 0f;
    private float rotationX = 0f;
    public float rotationXSpeed = 0.025f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float lastX = 0f;

    // Update is called once per frame
    void Update()
    {
        rotationZ += Input.GetAxis("Horizontal") * rotationZSpeed;
        rotationZ = Mathf.Clamp(rotationZ, -10, 10);

        Transform wagTransform = WagBone.transform;
        wagTransform.localEulerAngles = new Vector3(wagTransform.localEulerAngles.x, wagTransform.localEulerAngles.y, rotationZ);

        rotationX += Input.GetAxis("Vertical") * rotationXSpeed;
        rotationX = Mathf.Clamp(rotationX, -98, 98);

        Transform cantTransform = CantBone.transform;
        cantTransform.localEulerAngles = new Vector3(rotationX, cantTransform.localEulerAngles.y, cantTransform.localEulerAngles.z);

    }
}
