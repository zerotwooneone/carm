using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarmInput : MonoBehaviour
{
    public GameObject WagBone;
    public GameObject CantBone;
    public GameObject RainbowBone;
    public GameObject ParticleObject;
    public GameObject CarmBase;
    private ParticleSystem _particleFountain;
    public float wagSpeed = 0.025f;
    private float wagDegrees = 0f;
    private float cantDegrees = 0f;
    private float rainbowDegrees = 0f;
    public float cantSpeed = 0.025f;
    public float rainbowSpeed = 0.025f;
    public float TranslateSpeed = 0.005f;
    public bool Translate = true;
    // Start is called before the first frame update
    void Start()
    {
        _particleFountain = ParticleObject.GetComponent<ParticleSystem>();
    }

    private float lastX = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ModeSelection"))
        {
            Translate = !Translate;
        }

        if (Translate)
        {
            var localPosition = CarmBase.transform.localPosition;
            float newX = localPosition.x + (Input.GetAxis("Horizontal") * TranslateSpeed);
            float newZ = localPosition.z + (Input.GetAxis("Vertical") * TranslateSpeed);
            var newPosition = new Vector3(newX, localPosition.y, newZ);
            CarmBase.transform.localPosition = newPosition;
        } else
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
        

        if((Input.GetAxis("Jump") != 0))
        {
            //we must check to see if it is allready playing or else it will never play
            if (!_particleFountain.isPlaying)
            {
                Debug.LogWarning($"Jump! isPlaying{_particleFountain.isPlaying}");
                _particleFountain.Play();
            }            
        }
        else
        {
            //we must check to see if it is allready playing or else it will never start
            if (_particleFountain.isPlaying)
            {
                _particleFountain.Stop();
            }
            
        }

    }
}
