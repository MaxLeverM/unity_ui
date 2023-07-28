using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using UnityEngine;

namespace RedPanda.Project.UI.UIElements
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