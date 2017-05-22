using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractal : MonoBehaviour {

    public Mesh mesh;
    public Material material;
    [Range(1, 1000)]
    public int maxChildren = 5;
    private int depth=1;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth <= maxChildren)
        {
            new GameObject("Fractal Child" + depth).AddComponent<fractal>().Initialize(this);
        }
    }

    private void Initialize(fractal parent)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxChildren = parent.maxChildren;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
