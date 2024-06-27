using UnityEngine;

public class Package : MonoBehaviour
{
    #region MonoBehaviour

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag(Constants.Tags[Constants.Tag.Driver]))
        {
            GetComponent<Collider2D>().enabled = false;
            PickUpThePackage();
        }
    }

    #endregion

    #region Methods

    private void PickUpThePackage()
    {
        gameObject.SetActive(false);
        FindObjectOfType<Driver>().PackagePickedUp();
        FindObjectOfType<Delivery>().ActivateNextCustomer();
    }

    #endregion
}
