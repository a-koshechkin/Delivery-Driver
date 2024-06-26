using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    #region Fields

    [SerializeField] private List<Package> _packages;
    [SerializeField] private List<Customer> _customers;

    private int _currentPackageIndex;
    private int _currentCustomerIndex;

    private Navigation _navigation;

    #endregion

    #region MonoBehaviour

    private void Start()
    {
        _navigation = FindObjectOfType<Navigation>();
        ActivateFirstPackage();
    }

    #endregion

    #region Methods

    private void ActivateFirstPackage()
    {
        if (_packages != null && _customers != null && _packages.Count > 0 && _customers.Count > 0)
        {
            foreach (var package in _packages)
            {
                package.gameObject.SetActive(false);
            }
            foreach (var customer in _customers)
            {
                customer.gameObject.SetActive(false);
            }

            _currentPackageIndex = -1;
            _currentCustomerIndex = -1;

            ActivateNextPackage();
        }
    }

    public void ActivateNextPackage()
    {
        _currentPackageIndex++;
        if (_currentPackageIndex < _packages.Count)
        {
            _packages[_currentPackageIndex].gameObject.SetActive(true);
            _navigation.SetNewGoal(_packages[_currentPackageIndex].transform);
        }
        else
        {
            _navigation.SetNewGoal(null);
            SceneLoader.LoadNextScene();
        }
    }

    public void ActivateNextCustomer()
    {
        _currentCustomerIndex++;
        if (_currentCustomerIndex < _customers.Count)
        {
            _customers[_currentCustomerIndex].gameObject.SetActive(true);
            _navigation.SetNewGoal(_customers[_currentCustomerIndex].transform);
        }
        else
        {
            _navigation.SetNewGoal(null);
            SceneLoader.LoadNextScene();
        }
    }

    #endregion
}
