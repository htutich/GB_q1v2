using UnityEngine;


public class MoveObjectDown : MonoBehaviour, IInteractable
{ 
    #region Fields
    
    private float _speed = 2.0f;

    #endregion


    #region UnityMethods

    private void Start()
    {
    }

    private void Update()
    {
        
    }

    #endregion


    #region Methods
    public void Interact()
    {
        transform.position += Vector3.down * 2.0f;
        //throw new System.NotImplementedException();
    }

    #endregion
}
