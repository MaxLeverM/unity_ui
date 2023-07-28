using RedPanda.Project.Data;
using UnityEngine;

namespace RedPanda.Project.Configs
{
    public interface IPromoConfig
    {
        public Sprite GetItemIcon(string iconName);
        public Sprite GetItemBackground(PromoRarity rarity);
    }
}