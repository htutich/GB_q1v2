using UnityEngine;


[RequireComponent(typeof(Animator))]
public class DanceFall : MonoBehaviour
{
    #region Fields

    [SerializeField] private Rigidbody _rigidbodyToPush;
    [SerializeField] private float _killForce = 1.0f;

    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;
    private Animator _animator;

    private bool _animationEnd = false;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();

        SetRagdollState(false);
        SetMainPhysics(true);
    }

    private void Update()
    {
        if (!_animationEnd && _animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            _animationEnd = true;

            SetRagdollState(true);
            SetMainPhysics(false);

            var body = _rigidbodyToPush;
            var force = body.transform.up;

            force = force * _killForce * body.mass;
            body.AddForce(force, ForceMode.Impulse);

        }
    }

    #endregion


    #region Methods

    private void SetRagdollState(bool activityState)
    {
        for (int i = 1; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = !activityState;
            _colliders[i].enabled = activityState;
        }
    }

    private void SetMainPhysics(bool activityState)
    {
        _animator.enabled = activityState;
        _colliders[0].enabled = activityState;
    }

    #endregion
}

