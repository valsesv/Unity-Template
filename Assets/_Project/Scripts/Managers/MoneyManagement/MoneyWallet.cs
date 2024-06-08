using System;
using UnityEngine;

namespace valsesv._Project.Scripts.Managers.MoneyManagement
{
    public class MoneyWallet : MonoBehaviour
    {
        [SerializeField] private float moneyCount;

        private const string SaveKey = "Money";
        public event Action MoneyCountChanged;
        public float MoneyCount => moneyCount;

        private void Start()
        {
            Load();
        }

        public void Add(float addAmount)
        {
            moneyCount += addAmount;
            MoneyCountChanged?.Invoke();

            Save();
        }

        public void Get(int getAmount)
        {
            Add(-getAmount);
        }

        private void Save()
        {
            PlayerPrefs.SetFloat(SaveKey, moneyCount);
        }

        private void Load()
        {
            moneyCount = PlayerPrefs.GetFloat(SaveKey, moneyCount);

            MoneyCountChanged?.Invoke();
        }
    }
}
