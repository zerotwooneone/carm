using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTracking : MonoBehaviour
{
    public GameObject Source;
    public GameObject Target;
    private LineRenderer _lineRenderer;
    public GameObject LineObject;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = LineObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPositions(new[] { Source.transform.position, Target.transform.position });
    }
}
