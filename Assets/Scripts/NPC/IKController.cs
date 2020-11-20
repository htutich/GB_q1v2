using UnityEngine;


[RequireComponent(typeof(Animator))]
public class IKController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _leftHandObject = null;
    [SerializeField] private Transform _rightHandObject = null;
    [SerializeField] private Transform _lookObject = null;

    [SerializeField] private bool _ikActive = false;

    private Animator _animator;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        if (_animator)
        {
            if (_ikActive)
            {
                if (_lookObject != null)
                {
                    _animator.SetLookAtWeight(1);
                    _animator.SetLookAtPosition(_lookObject.transform.position);
                }

                if (_leftHandObject != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandObject.position);
                    _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandObject.rotation);
                }

                if (_rightHandObject != null)
                {
                    _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                    _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandObject.position);
                    _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandObject.rotation);
                }
            }

            else
            {
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                _animator.SetLookAtWeight(0);
            }
        }
    }

    #endregion
}

