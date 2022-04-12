using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmInput : MonoBehaviour
{
    public GameObject WagBone;
    public GameObject CantBone;
    public GameObject RainbowBone;
    public float wagSpeed = 0.025f;
    private float wagDegrees = 0f;
    private float cantDegrees = 0f;
    private float rainbowDegrees = 0f;
    public float cantSpeed = 0.025f;
    public float rainbowSpeed = 0.025f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float lastX = 0f;

    // Update is called once per frame
    void Update()
    {
        const float maxWagDegrees = 10;
        const float minWagDegrees = -maxWagDegrees;
        wagDegrees += Input.GetAxis("Horizontal") * wagSpeed;
        wagDegrees = Mathf.Clamp(wagDegrees, minWagDegrees, maxWagDegrees);

        Transform wagTransform = WagBone.transform;
        wagTransform.localEulerAngles = new Vector3(wagTransform.localEulerAngles.x, wagTransform.localEulerAngles.y, wagDegrees);

        const float maxCantDegrees = 88;
        const float minCantDegrees = -maxCantDegrees;
        cantDegrees += Input.GetAxis("Vertical") * cantSpeed;
        cantDegrees = Mathf.Clamp(cantDegrees, minCantDegrees, maxCantDegrees);

        Transform cantTransform = CantBone.transform;
        cantTransform.localEulerAngles = new Vector3(cantDegrees, cantTransform.localEulerAngles.y, cantTransform.localEulerAngles.z);

        const float maxRainbowDegrees = 98;
        const float minRainbowDegrees = -maxCantDegrees;
        rainbowDegrees += Input.GetAxis("Rainbow") * rainbowSpeed;
        rainbowDegrees = Mathf.Clamp(rainbowDegrees, minRainbowDegrees, maxRainbowDegrees);

        Transform rainbowTransform = RainbowBone.transform;
        rainbowTransform.localEulerAngles = new Vector3(rainbowTransform.localEulerAngles.x, rainbowDegrees, rainbowTransform.localEulerAngles.z);

    }
}
