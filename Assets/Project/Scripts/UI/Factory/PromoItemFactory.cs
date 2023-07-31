using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Constants;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI.UIElements;
using UnityEngine;

namespace RedPanda.Project.UI.Factory
{
    public class PromoItemFactory : ElementFactory<IPromoModel>
    {
        private IExportLocatorScope _container;

        [Import]
        public void Inject(IExportLocatorScope container, IPromoService promoService)
        {
            _container = container;
        }

        public override UIElement CreateElement(IPromoModel model, Transform root)
        {
            var view = Object.Instantiate(Resources.Load<ItemView>($"UI/{ViewConst.ItemView}"), root);
            _container.Inject(view);
            view.Setup(model);
            return view;
        }
    }
}