using System;
using RedPanda.Project.Configs;
using RedPanda.Project.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI.UIElements
{
    public class ItemView : UIElement
    {
        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _itemImage;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Button _promoButton;

        private IPromoModel _promoModel;
        private IPromoConfig _promoConfig;

        private void Awake()
        {
            _promoButton.onClick.AddListener(OnPromoBtnPressed);
        }

        public void Setup(IPromoModel model)
        {
            _promoModel = model;
            
            _headerText.text = model.Title;
            _backgroundImage.sprite = _promoConfig.GetItemBackground(model.Rarity);
            _itemImage.sprite = _promoConfig.GetItemIcon(model.GetIcon());
            _priceText.text = $"x{model.Cost}";
        }

        protected override void OnInjected()
        {
            _promoConfig = Container.Locate<IPromoConfig>();
        }

        private void OnPromoBtnPressed()
        {
            throw new NotImplementedException();
        }
    }
}