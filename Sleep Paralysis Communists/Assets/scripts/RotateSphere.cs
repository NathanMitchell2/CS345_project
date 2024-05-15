using UnityEngine;

public class RotateSphere : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 10f;

    private Quaternion initialRotation;

    void Start()
    {
        // Randomize the rotation axis
        rotationAxis = Random.onUnitSphere;

        // Store the initial rotation of the sphere
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Rotate the sphere and its children continuously
        Quaternion targetRotation = Quaternion.Euler(initialRotation.eulerAngles + rotationAxis * Time.time * rotationSpeed);
        transform.rotation = targetRotation;

        foreach (Transform child in transform)
        {
            child.rotation = targetRotation;
        }
    }
}
