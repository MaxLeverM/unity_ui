using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI.UIElements
{
    public class FinanceBarView : UIElement
    {
        [SerializeField] private TMP_Text _rubyText;
        private IUserService _userService;

        protected override void OnInjected()
        {
            _userService = Container.Locate<IUserService>();
            
            SetRubyAmount(_userService.Currency);
            _userService.OnCurrencyChanged += SetRubyAmount;
        }

        private void OnDestroy()
        {
            _userService.OnCurrencyChanged -= SetRubyAmount;
        }

        private void SetRubyAmount(int amount)
        {
            _rubyText.text = $"<sprite=0>{amount}"; //TODO сделать чтобы для больших чисел добавлялся суффикс
        }
    }
}