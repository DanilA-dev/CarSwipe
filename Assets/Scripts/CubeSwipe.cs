using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CubeSwipe : MonoBehaviour
{
    private Camera playerCamera;
    private Rigidbody body;

    private Vector3 mouseOffset;
    private Vector3 newPos;
    private float mouseZ;

    private bool isMovable = true;
    
    private void Awake()
    {
        playerCamera = FindObjectOfType<Camera>();
        body = GetComponent<Rigidbody>();
    }


    private void OnMouseUp()
    {
      if(body != null)
        {
            if(isMovable)
            {
              body.velocity = new Vector3(mouseOffset.x * 10f, 0f, transform.position.z);
              body.AddTorque(mouseOffset.x * 5f, 0f, 0f, ForceMode.Impulse);
            }
        }
    }

    private void OnMouseDown()
    {
        if(isMovable)
        {
            mouseZ = playerCamera.WorldToScreenPoint(transform.position).z;
            mouseOffset = transform.position - MouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if(isMovable)
        {
          newPos = new Vector3(MouseWorldPosition().x + mouseOffset.x, transform.position.y, transform.position.z);
          transform.position = newPos;
        }
    }

    public void DisableMovement()
    {
        isMovable = false;
    }

    private Vector3 MouseWorldPosition()
    {
        var mousePos = Input.mousePosition;
        mousePos.y = 0f;
        mousePos.z = mouseZ;
        return playerCamera.ScreenToWorldPoint(mousePos);
    }
}
