using UnityEngine;

// A very simplistic car driving on the x-z plane.

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 0f;

    private float energy = 0;

    Vector3 currentPosition;
    void Start()
    {
        currentPosition = transform.position;
    }
    void Update()
    {
        if (energy > 0)
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * 0;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            // Move translation along the object's z-axis
            transform.Translate(0, translation, 0);

            // Rotate around our y-axis
            transform.Rotate(0, 0, -rotation);

            energy = energy - Vector3.Distance(currentPosition, transform.position);

            currentPosition = transform.position;
        }

    }

    public void SetAngle(int angle)
    {
        transform.Rotate(0, 0, -angle);
    }
    public void AddEnergy(int amount)
    {
        energy = amount;
    }
    public float GetEnergy()
    {
        return energy;
    }
}