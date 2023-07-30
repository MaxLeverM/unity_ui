using System.Linq;
using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Constants;
using RedPanda.Project.Data;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI.UIElements;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RedPanda.Project.UI.Factory
{
    public class CategoryFactory : ElementFactory<CategoryView, PromoType>
    {
        private IExportLocatorScope _container;
        private IPromoService _promoService;

        [Import]
        public void Inject(IExportLocatorScope container, IPromoService promoService)
        {
            _container = container;
            _promoService = promoService;
        }

        public override CategoryView CreateElement(PromoType type, Transform root)
        {
            var promos = _promoService.GetPromos();
            var models = promos.Where(x => x.Type == type).OrderByDescending(x => x.Rarity);

            var view = Object.Instantiate(Resources.Load<CategoryView>($"UI/{ViewConst.CategoryView}"), root);
            _container.Inject(view);
            view.Setup(type.ToString(), models);
            return view;
        }
    }
}