using RedPanda.Project.UI.UIElements;
using UnityEngine;

namespace RedPanda.Project.UI.Factory
{
    public abstract class ElementFactory<T,K> where T : UIElement
    {
        public abstract T CreateElement(K data, Transform root);
    }
}