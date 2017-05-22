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
    [Range(0, 5)]
    public float drawDelay = 0.2f;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        if (depth <= maxChildren)
        {
            StartCoroutine(createChildren());
        }
    }

    IEnumerator createChildren()
    {
        yield return new WaitForSeconds(drawDelay);
        new GameObject("Fractal Child.Up." + depth).AddComponent<fractal>().Initialize(this, Vector3.up, Quaternion.identity);
        yield return new WaitForSeconds(drawDelay);
        new GameObject("Fractal Child.Right." + depth).AddComponent<fractal>().Initialize(this, Vector3.right, Quaternion.Euler(0, 0, -90));
        yield return new WaitForSeconds(drawDelay);
        new GameObject("Fractal Child.Left." + depth).AddComponent<fractal>().Initialize(this, Vector3.left, Quaternion.Euler(0, 0, 90));
    }

    private void Initialize(fractal parent, Vector3 direction, Quaternion orientation)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxChildren = parent.maxChildren;
        childScale = parent.childScale;
        objectSize = transform.root.localScale;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        transform.localScale = objectSize * childScale;
        transform.localPosition = direction * (objectSize.y / 2 + 0.5f * childScale);
        transform.localRotation = orientation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
