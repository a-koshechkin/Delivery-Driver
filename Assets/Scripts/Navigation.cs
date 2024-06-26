using UnityEngine.UI;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    #region Fields

    [SerializeField] private Image _arrow;

    private Transform _nextGoal;
    private Transform _driver;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        _driver = FindObjectOfType<Driver>().transform;
    }

    private void Update()
    {
        UpdateImageRotation();
    }

    #endregion

    #region Methods

    public void SetNewGoal(Transform goal)
    {
        if (goal == null)
        {
            _arrow.gameObject.SetActive(false);
        }
        else
        {
            _nextGoal = goal;
            _arrow.gameObject.SetActive(true);
        }
    }

    private void UpdateImageRotation()
    {
        if (_arrow != null && _nextGoal != null)
        {
            Vector3 direction = _nextGoal.position - _driver.position;
            _arrow.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        }
    }

    #endregion
}
