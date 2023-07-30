using System.Collections.Generic;
using System.Linq;
using Grace.DependencyInjection;
using RedPanda.Project.Interfaces;
using RedPanda.Project.UI.Factory;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI.UIElements
{
    public class CategoryView : UIElement
    {
        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private RectTransform _content;
        private List<IPromoModel> _models;
        private ElementFactory<ItemView, IPromoModel> _itemFactory;

        protected override void OnInjected()
        {
            _itemFactory = new PromoItemFactory();
            Container.Inject(_itemFactory);
        }

        public void Setup(string name, IEnumerable<IPromoModel> models)
        {
            _headerText.text = name;
            _models = models.ToList();
            
            foreach (var model in _models)
            {
                _itemFactory.CreateElement(model, _content);
            }
        }
    }
}