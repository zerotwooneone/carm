using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTracking : MonoBehaviour
{
    public GameObject Source;
    public GameObject Target;
    private LineRenderer _lineRenderer;
    public GameObject LineObject;
    private GameObject _lines;
    private IEnumerable<Action> _updateLines;
    // Start is called before the first frame update
    void Start()
    {
        var updateLines = new List<Action>();
        _updateLines = updateLines;

        _lineRenderer = LineObject.GetComponent<LineRenderer>();
        _lines = new GameObject();
        _lines.name = $"{Source.name} Lines";
        _lines.transform.parent = Target.transform;

        Func<Vector3> targetStart = () => Target.transform.position;
        Func<Vector3> targetForward = () => Target.transform.position + Target.transform.forward;
        updateLines.Add( CreateLine(targetStart, targetForward, Color.blue));

        Func<Vector3> targetUp = ()=> Target.transform.position + Target.transform.up;
        updateLines.Add(CreateLine(targetStart, targetUp, Color.green));

        Func<Vector3> targetRight = () => Target.transform.position + Target.transform.right;
        updateLines.Add(CreateLine(targetStart, targetRight, Color.red));
    }

    private Action CreateLine(Func<Vector3> start, Func<Vector3> end, Color color)
    {
        var go = new GameObject();
        var lineRenderer = go.AddComponent<LineRenderer>();
        go.transform.parent = _lines.transform;
        lineRenderer.startWidth = 0.05f;

        //clone the material of the target
        var material = new Material(Target.GetComponent<Renderer>().material);

        lineRenderer.sharedMaterial = material;
        lineRenderer.sharedMaterial.SetColor("_Color", color);
        return () =>
        {
            lineRenderer.SetPositions(new[] { start(), end() });
        };
    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPositions(new[] { Source.transform.position, Target.transform.position });

        
        foreach (var update in _updateLines)
        {
            update();
        }
    }
}
