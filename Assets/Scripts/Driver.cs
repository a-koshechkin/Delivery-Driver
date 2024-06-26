using System.Collections;
using UnityEngine;

using static Constants;

public class Driver : MonoBehaviour
{
    #region Fields

    private float _moveSpeed;
    private readonly float _steerSpeed = 300f;
    private readonly float _normalMoveSpeed = 20f;
    private readonly float _boostDuration = 2f;
    private readonly float _slowDownDuration = 2f;
    private readonly float _boostPower = 2f;
    private readonly float _slowDownPower = 2f;
    private readonly string _horizontalAxisName = "Horizontal";
    private readonly string _verticalAxisName = "Vertical";

    private SpriteRenderer _spriteRenderer;
    private Color _hasPackageColor = Color.green;
    private Color _noPackageColor = Color.white;

    #endregion

    #region MonoBehaviour

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _noPackageColor;

        ResetSpeed();
    }

    void Update()
    {
        if (Input.GetAxis(_verticalAxisName) == 0)
        {
            ResetSpeed();
        }
        else
        {
            transform.Rotate(0, 0, -_steerSpeed * Input.GetAxis(_horizontalAxisName) * Input.GetAxis(_verticalAxisName) * Time.deltaTime);
            transform.Translate(0, _moveSpeed * Input.GetAxis(_verticalAxisName) * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ResetSpeed();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag(Tags[Tag.SpeedUp]))
            {
                BoostSpeed();
            }
            if (collision.CompareTag(Tags[Tag.SlowDown]))
            {
                SlowDown();
            }
        }
    }

    #endregion

    #region Methods

    private void ResetSpeed()
    {
        _moveSpeed = _normalMoveSpeed;
        StopAllCoroutines();
    }

    private void BoostSpeed()
    {
        _moveSpeed *= _boostPower;
        StartCoroutine(CancelSpeedBoost());
    }

    private void SlowDown()
    {
        _moveSpeed /= _slowDownPower;
        StartCoroutine(CancelSlowDown());
    }

    public void PackageDelivered()
    {
        _spriteRenderer.color = _noPackageColor;
    }

    public void PackagePickedUp()
    {
        _spriteRenderer.color = _hasPackageColor;
    }

    #endregion

    #region Coroutines

    private IEnumerator CancelSlowDown()
    {
        yield return new WaitForSeconds(_slowDownDuration);
        _moveSpeed *= _slowDownPower;
    }

    private IEnumerator CancelSpeedBoost()
    {
        yield return new WaitForSeconds(_boostDuration);
        _moveSpeed /= _boostPower;
    }

    #endregion
}
