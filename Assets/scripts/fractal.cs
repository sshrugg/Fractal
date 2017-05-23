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
    private static Vector3[] childDirections = {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };
    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

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
        for (int i = 0; i < childDirections.Length; i++)
        {
            yield return new WaitForSeconds(drawDelay);
            new GameObject("Fractal Child.Up." + depth).AddComponent<fractal>().Initialize(this, i);
        }
    }

    private void Initialize(fractal parent, int childIndex)
    {
        mesh = parent.mesh;
        material = parent.material;
        maxChildren = parent.maxChildren;
        childScale = parent.childScale;
        objectSize = transform.root.localScale;
        depth = parent.depth + 1;
        transform.parent = parent.transform;
        transform.localScale = objectSize * childScale;
        transform.localPosition = childDirections[childIndex] * (objectSize.y / 2 + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
