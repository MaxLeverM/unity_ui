using RedPanda.Project.UI.UIElements;
using UnityEngine;

namespace RedPanda.Project.UI.Factory
{
    public abstract class ElementFactory<T>
    {
        public abstract UIElement CreateElement(T data, Transform root);
    }
}