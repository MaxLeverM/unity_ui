using System.Linq;
using Grace.DependencyInjection;
using RedPanda.Project.Data;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.UI.Factory;
using RedPanda.Project.UI.UIElements;
using UnityEngine;

namespace RedPanda.Project.UI.Views
{
    public sealed class PromoView : View
    {
        [SerializeField] private RectTransform _categoryContent;
        [SerializeField] private FinanceBarView _financeBarView;
        private IPromoService _promoService;
        private ElementFactory<CategoryView, PromoType> _categoryFactory;

        protected override void OnInjected()
        {
            Container.Inject(_financeBarView);
            _promoService = Container.Locate<IPromoService>();
            _categoryFactory = new CategoryFactory();
            Container.Inject(_categoryFactory);
            
            CreateCategories();
        }

        private void CreateCategories()
        {
            var promos = _promoService.GetPromos();
            var categoryTypes = promos.GroupBy(x => x.Type).Select(x=>x.Key);
            
            foreach (var categoryType in categoryTypes)
            {
                _categoryFactory.CreateElement(categoryType, _categoryContent);
            }
        }
    }
}