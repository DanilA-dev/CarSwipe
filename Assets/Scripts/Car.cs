using UnityEngine;
using UnityEngine.Events;


public class Car : MonoBehaviour
{
    [SerializeField] private float carSpeed;
    [SerializeField] private Rigidbody carBody;

    #region EVENTS

    [SerializeField] private UnityEvent OnCubeCollide;
    [SerializeField] private UnityEvent OnLevelFinished;

    #endregion

    #region PROPERTIES
    public float CarSpeed { get => carSpeed; }
    public Rigidbody CarBody { get => carBody; }

    #endregion


    private void FixedUpdate()
    {
       carBody.velocity = transform.forward * carSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            StopMovement();
            OnCubeCollide?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {
           StopMovement();
           OnLevelFinished?.Invoke();
        }
    }

    private void StopMovement()
    {
        carBody.velocity = Vector3.zero;
        carBody.isKinematic = true;
    }

}
