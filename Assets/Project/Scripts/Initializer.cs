using Grace.DependencyInjection;
using RedPanda.Project.Configs;
using RedPanda.Project.Constants;
using RedPanda.Project.Services;
using RedPanda.Project.Services.Interfaces;
using RedPanda.Project.Services.UI;
using UnityEngine;

namespace RedPanda.Project
{
    public sealed class Initializer : MonoBehaviour
    {
        [SerializeField] private PromoConfig _promoConfig;
        private DependencyInjectionContainer _container = new();

        private void Awake()
        {
            _container.Configure(block =>
            {
                block.Export<UserService>().As<IUserService>().Lifestyle.Singleton();
                block.Export<PromoService>().As<IPromoService>().Lifestyle.Singleton();
                block.Export<UIService>().As<IUIService>().Lifestyle.Singleton();
                block.ExportInstance(_promoConfig).As<IPromoConfig>().Lifestyle.Singleton();
            });

            _container.Locate<IUserService>();
            _container.Locate<IPromoService>();
            _container.Locate<IUIService>().Show(ViewConst.LobbyView);
            _container.Locate<IPromoConfig>();
        }
    }
}