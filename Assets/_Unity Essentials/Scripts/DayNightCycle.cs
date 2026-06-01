using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Day/Night Settings")]
    [Tooltip("Length of a full day in real-world seconds.")]
    [Min(1f)]
    public float dayLengthSeconds = 300f;

    [Tooltip("Axis around which the sun rotates.")]
    public Vector3 rotationAxis = Vector3.right;

    private float degreesPerSecond;

    private void Start()
    {
        UpdateRotationSpeed();
    }

    private void Update()
    {
        if (dayLengthSeconds <= 0f)
            return;

        degreesPerSecond = 360f / dayLengthSeconds;

        transform.Rotate(
            rotationAxis.normalized,
            degreesPerSecond * Time.deltaTime,
            Space.World);
    }

    private void OnValidate()
    {
        UpdateRotationSpeed();
    }

    private void UpdateRotationSpeed()
    {
        if (dayLengthSeconds > 0f)
        {
            degreesPerSecond = 360f / dayLengthSeconds;
        }
    }
}