using System;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Services
{
    public sealed class UserService : IUserService
    {
        private int _currency;
        public int Currency
        {
            get => _currency;
            private set
            {
                _currency = value;
                OnCurrencyChanged?.Invoke(_currency);
            }
        }

        public event Action<int> OnCurrencyChanged; 

        public UserService()
        {
            Currency = 1000;
        }

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
        }

        void IUserService.ReduceCurrency(int delta)
        {
            Currency -= delta;
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return Currency >= amount;
        }
    }
}