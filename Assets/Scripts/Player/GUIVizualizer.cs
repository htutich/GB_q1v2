using UnityEngine;


public class GUIVizualizer : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _currentHealth;
    private int _minHealth = 0;
    private int _maxHealth = 100;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnGUI()
    {
        _currentHealth = DrawHealth(_minHealth, _maxHealth, _currentHealth);
    }

    #endregion


    #region Methods
    
    private int DrawHealth(int minHealth, int maxHealth, int currentHealth)
    {
        GUI.Box(new Rect(0, Screen.height - 50, 100, 50), $"{currentHealth} HP");
        return currentHealth;
    }
    
    #endregion
}
