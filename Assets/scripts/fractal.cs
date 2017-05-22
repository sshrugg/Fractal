using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fractal : MonoBehaviour {

    public Mesh mesh;
    public Material material;
    [Range(1, 100)]
    public int maxChildren = 5;
    private int depth = 1;
    [Range(0, 1)]
    public float childScale = 0.5f;
    Vector3 objectSize;

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
        childScale = parent.childScale;
        objectSize = transform.root.localScale;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        transform.localScale = objectSize * childScale;
        transform.localPosition = Vector3.up * (objectSize.y / 2 + 0.5f * childScale);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
