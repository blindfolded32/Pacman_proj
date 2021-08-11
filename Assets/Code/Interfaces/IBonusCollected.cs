using UnityEngine.EventSystems;

namespace Scripts.Game
{
    public interface IBonusCollected : IEventSystemHandler

    {
        void OnBonusCollected(float bonus, PlayerControl player);
        void OnBonusExpired(PlayerControl player);
        void OnPillBonusCollected(float bonus, PlayerControl player);
        void OnPillBonusExpired(PlayerControl player);
    }
}
