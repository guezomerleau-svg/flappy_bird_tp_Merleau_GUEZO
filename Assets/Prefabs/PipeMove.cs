using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PipeMove : MonoBehaviour
{
    public float speed = 3f;
    public float deadZone = -18f; // Position X où la colonne disparaît

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}