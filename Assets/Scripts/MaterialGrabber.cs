using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGrabber : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    
    public static int material;
    
    public static int STEEL = 0;
    public static int ICE = 1;
    public static int WOOD = 2;
    public static int COPPER = 3;

    private bool isGrabReady = true;
    public float raycastDistance = 3.0f;
    
    private Vector2 playerPos;
    private Vector2 aimDirection;

    private Vector3[] linePositions = new Vector3[2];
    
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        playerPos = this.transform.position;
        
        float aimHorizontal = Input.GetAxisRaw("ArrowKeysHorizontal");
        float aimVertical = Input.GetAxisRaw("ArrowKeysVertical");
        
        aimDirection = new Vector2(aimHorizontal,aimVertical).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GrabMaterial();
        }
        Debug.DrawLine(this.transform.position, this.transform.position + (new Vector3(aimDirection.x, aimDirection.y,0) * raycastDistance));
    }

    void GrabMaterial()
    {
        RaycastHit2D hit = Physics2D.Raycast(playerPos, aimDirection, raycastDistance);
        if (hit.collider.CompareTag("Steel"))
        {
            material = STEEL;
        }
        if (hit.collider.CompareTag("Ice"))
        {
            material = ICE;
        }
        if (hit.collider.CompareTag("Wood"))
        {
            material = WOOD;
        }
        if (hit.collider.CompareTag("Copper"))
        {
            material = COPPER;
        }
        linePositions[1] = hit.transform.position;
    }

    void DrawGrabLine()
    {
        //_lineRenderer.SetPositions(linePositiions);
    }
}
