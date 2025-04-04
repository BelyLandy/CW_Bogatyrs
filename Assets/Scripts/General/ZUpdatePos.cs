using UnityEngine;

public class ZUpdatePos : MonoBehaviour
{
    private float zOffsetMultiplier = 1f;

    void FixedUpdate()
    {
        var transform1 = transform;
        var position = transform1.position;
        var zPosition = position.y * zOffsetMultiplier;
        position = new Vector3(position.x, position.y, zPosition);
        transform1.position = position;
    }
}
