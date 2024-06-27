using System.Collections;
using UnityEngine;

using static Constants;

public class Customer : MonoBehaviour
{
    #region Fields

    private readonly float _customerReloadTime = 0.2f;
    private Color _receivedPackage = Color.black;

    #endregion

    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(Tags[Tag.Driver]))
        {
            GetComponent<Collider2D>().enabled = false;
            DeliverPackage();
        }
    }

    #endregion

    #region Methods

    private void DeliverPackage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = _receivedPackage;
        FindObjectOfType<Driver>().PackageDelivered();
        FindObjectOfType<Delivery>().ActivateNextPackage();
        StartCoroutine(HideCustomer());
    }

    #endregion

    #region Coroutines

    private IEnumerator HideCustomer()
    {
        yield return new WaitForSeconds(_customerReloadTime);
        gameObject.SetActive(false);
    }

    #endregion
}
