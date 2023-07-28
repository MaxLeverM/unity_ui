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
        [SerializeField] private List<Sprite> itemIcons;

        public Sprite GetItemIcon(string iconName)
        {
            return itemIcons.FirstOrDefault(x => x.name.Equals(iconName));
        }

        public Sprite GetItemBackground(PromoRarity rarity)
        {
            return _rarityBackgrounds.FirstOrDefault(x => x.Rarity.Equals(rarity))?.Background;
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