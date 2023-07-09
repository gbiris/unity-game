using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    private Vector2 vel;
    private float zoomVel;
    private Camera cam;
    private float defaultZoom;
    private Vector2 offset;
    
    public static CameraMovement Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        cam = GetComponent<Camera>();
        defaultZoom = cam.orthographicSize;
        offset = new Vector2(0f, 0f);
    }

    private void FixedUpdate()
    {
        if (!(player == null))
        {
            float num = PlayerMovement.Instance.GetVel().magnitude / 6f;
            Vector2 target = (Vector2)player.position + PlayerMovement.Instance.GetVel() * 0.3f + offset;
            base.transform.position = Vector2.SmoothDamp(base.transform.position, target, ref vel, 0.3f);
            base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -10f);
            cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, defaultZoom + num, ref zoomVel, 0.6f);
        }
    }

    public void Restart()
    {
        base.transform.position = player.position;
    }

    public void SetMenu()
    {
        offset = Vector2.zero;
    }

    public void SetStart()
    {
        offset = new Vector2(6f, 0f);
    }
}