using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        protected IExportLocatorScope Container { get; private set; }
        
        [Import]
        public void Inject(IExportLocatorScope container)
        {
            Container = container;
            OnInjected();
        }

        protected virtual void OnInjected()
        {
        }
    }
}