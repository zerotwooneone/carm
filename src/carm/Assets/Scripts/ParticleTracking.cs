using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTracking : MonoBehaviour
{
    public GameObject ParticleParent;
    public GameObject Target;
    private ParticleSystem _particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = ParticleParent.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        _particleSystem.transform.LookAt(Target.transform.position);
    }
}
