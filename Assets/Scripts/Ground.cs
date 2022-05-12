using UnityEngine;

public class Ground : MonoBehaviour
{
    private Bounds _groundCollider;
    public float GroundX { get; private set; }
    public float GroundZ { get; private set; }

    private void Awake()
    {
        GetSize();
    }

    private void GetSize()
    {
        _groundCollider = GetComponent<Collider>().bounds;
        GroundX = _groundCollider.size.x;
        GroundZ = _groundCollider.size.z;
    }
}
