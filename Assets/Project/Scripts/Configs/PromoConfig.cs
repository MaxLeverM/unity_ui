using System;
using System.Collections.Generic;
using System.Linq;
using RedPanda.Project.Data;
using UnityEngine;

namespace RedPanda.Project.Configs
{
    [CreateAssetMenu(fileName = "PromoConfig", menuName = "ScriptableObjects/PromoConfig", order = 1)]
    public class PromoConfig : ScriptableObject, IPromoConfig
    {
        [SerializeField] private List<RarityBackground> _rarityBackgrounds;
        [SerializeField] private List<Sprite> _itemIcons;

        Sprite IPromoConfig.GetItemIcon(string iconName)
        {
            var result = _itemIcons.FirstOrDefault(x => x.name.Equals(iconName));
            if (result == null)
            {
                Debug.LogError($"Can't find item icon with name {iconName}");
            }

            return result;
        }

        Sprite IPromoConfig.GetItemBackground(PromoRarity rarity)
        {
            var result = _rarityBackgrounds.FirstOrDefault(x => x.Rarity.Equals(rarity))?.Background;
            if (result == null)
            {
                Debug.LogError($"Can't find item background for rarity {rarity}");
            }

            return result;
        }
    }

    [Serializable]
    internal class RarityBackground
    {
        [SerializeField] private PromoRarity _rarity;
        [SerializeField] private Sprite _background;

        public PromoRarity Rarity => _rarity;
        public Sprite Background => _background;
    }
}