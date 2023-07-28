using System.Collections.Generic;
using System.Linq;
using Grace.DependencyInjection;
using RedPanda.Project.Configs;
using RedPanda.Project.Constants;
using RedPanda.Project.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class CategoryView : UIElement
    {
        [SerializeField] private TMP_Text _headerText;
        [SerializeField] private RectTransform _content;
        private List<IPromoModel> _models;

        public void Setup(string name, IEnumerable<IPromoModel> models)
        {
            _headerText.text = name;
            _models = models.ToList();
            
            foreach (var model in _models)
            {
                var view = Object.Instantiate(Resources.Load<ItemView>($"UI/{ViewConst.ItemView}"), _content);
                Container.Inject(view);
                view.Setup(model);
            }
        }
    }
}