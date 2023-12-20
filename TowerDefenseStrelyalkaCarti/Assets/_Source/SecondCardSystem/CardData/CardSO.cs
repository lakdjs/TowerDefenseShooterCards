using System.Collections.Generic;
using UnityEngine;

namespace SecondCardSystem.CardData
{
    [CreateAssetMenu(menuName = "SO/New Card", fileName = "NewCard")]
    public class CardSO : ScriptableObject
    {
        [field: SerializeField] public List<Card> Cards { get; private set; }
    }
}
