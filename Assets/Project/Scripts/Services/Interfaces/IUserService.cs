using System;

namespace RedPanda.Project.Services.Interfaces
{
    public interface IUserService
    {
        int Currency { get; }
        void AddCurrency(int delta);
        bool ReduceCurrency(int delta);
        bool HasCurrency(int amount);
        event Action<int> OnCurrencyChanged;
    }
}