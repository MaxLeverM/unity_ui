using System;
using RedPanda.Project.Configs;
using RedPanda.Project.Data;
using RedPanda.Project.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public class ItemView : UIElement
    {
        [SerializeField] private TMP_Text headerText;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text priceText;

        private IPromoModel _promoModel;
        private IPromoConfig _promoConfig;

        protected override void OnInjected()
        {
            _promoConfig = Container.Locate<IPromoConfig>();
        }

        public void Setup(IPromoModel model)
        {
            _promoModel = model;
            
            headerText.text = model.Title;
            backgroundImage.sprite = _promoConfig.GetItemBackground(model.Rarity);
            itemImage.sprite = _promoConfig.GetItemIcon(model.GetIcon());
            priceText.text = $"x{model.Cost}";
        }
    }
}