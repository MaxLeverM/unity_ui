using RedPanda.Project.Data;
using UnityEngine;

namespace RedPanda.Project.Configs
{
    public interface IPromoConfig
    {
        Sprite GetItemIcon(string iconName);
        Sprite GetItemBackground(PromoRarity rarity);
    }
}