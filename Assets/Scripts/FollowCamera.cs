using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    #region Fields

    private Driver _driver;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _driver = FindObjectOfType<Driver>();
    }

    void LateUpdate()
    {
        transform.position = new Vector3(_driver.transform.position.x, _driver.transform.position.y, transform.position.z);
    }

    #endregion
}
