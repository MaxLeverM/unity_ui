using DG.Tweening;
using RedPanda.Project.Configs;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
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
        private IUserService _userService;

        private static readonly Vector3 PromoPressScale = new Vector3(1.1f, 1.1f, 1.1f);
        private static readonly float PromoAnimDuration = 0.1f;

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
            _userService = Container.Locate<IUserService>();
        }

        private void OnPromoBtnPressed()
        {
            if (_userService.ReduceCurrency(_promoModel.Cost))
            {
                Debug.Log($"{_promoModel.Title} purchased successfully");
            }

            transform.DOScale(PromoPressScale, PromoAnimDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}