using System;
using System.Linq;
using Grace.DependencyInjection;
using RedPanda.Project.Configs;
using RedPanda.Project.Constants;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RedPanda.Project.UI
{
    public sealed class PromoView : View
    {
        [SerializeField] private RectTransform _categoryContent;
        [SerializeField] private FinanceBarView _financeBarView;

        protected override void OnInjected()
        {
            Container.Inject(_financeBarView);
            
            var promoService = Container.Locate<IPromoService>();
            var promos = promoService.GetPromos();
            var categoryTypes = promos.GroupBy(x => x.Type).Select(x=>x.Key);
            
            foreach (var categoryType in categoryTypes)
            {
                var models = promos.Where(x => x.Type == categoryType).OrderByDescending(x=>x.Rarity);
                
                var view = Object.Instantiate(Resources.Load<CategoryView>($"UI/{ViewConst.CategoryView}"), _categoryContent);
                Container.Inject(view);
                view.Setup(categoryType.ToString(), models);
            }
        }
    }
}