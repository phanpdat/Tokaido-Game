using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowSmart : MonoBehaviour
{
    [Header("Refs")]
    public Transform target;
    public PlayerMover mover;

    [Header("Offsets")]
    public Vector3 followOffset = new Vector3(0, 12, -12); 
    public Vector3 arriveIdleOffset = new Vector3(0, 18, -18);
    private Vector3 startIdleOffset; 
    private Vector3 currentIdleOffset;

    [Header("Smooth")]
    public float followSmooth = 5f;
    public float zoomSmooth = 6f;

    [Header("Zoom")]
    public float movingFOV = 45f;
    private float idleFOV;

    private Camera cam;
    private bool wasMoving;

    void Awake()
    {
        cam = GetComponent<Camera>();
        idleFOV = cam.fieldOfView;

        if (target != null)
        {
            startIdleOffset = transform.position - target.position;
            currentIdleOffset = startIdleOffset;
        }
    }

    void LateUpdate()
    {
        if (!target || !mover) return;

        bool isMoving = mover.IsMoving;

        if (wasMoving && !isMoving)
        {
            currentIdleOffset = arriveIdleOffset;
        }

        Vector3 desiredPos = target.position + (isMoving ? followOffset : currentIdleOffset);
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSmooth * Time.deltaTime);

        float desiredFov = isMoving ? movingFOV : idleFOV;
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, desiredFov, zoomSmooth * Time.deltaTime);

        wasMoving = isMoving;
    }
}
