using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    #region Fields

    private Rigidbody _myRigidbody;
    private Animator _myAnimator;

    private float _speedMultiply = 1.0f;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _myRigidbody = GetComponent<Rigidbody>();
        _myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedMultiply = 2.0f;
        }
        else
        {
            _speedMultiply = 1.0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), transform.TransformDirection(Vector3.forward), out hit, 2.0f))
            {
                hit.collider.GetComponent<IInteractable>().Interact();
            }
        }
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), transform.TransformDirection(Vector3.forward) * 2.0f, Color.yellow);

    }

    private void FixedUpdate()
    {
        Walk();
    }

    #endregion


    #region Methods

    private void Walk()
    {
        _myAnimator.SetFloat("Speed", Input.GetAxisRaw("Vertical") * _speedMultiply);
        _myAnimator.SetFloat("Direction", Input.GetAxisRaw("Horizontal") * _speedMultiply);
    }

    #endregion
}
