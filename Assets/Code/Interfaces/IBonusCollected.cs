using UnityEngine.EventSystems;

namespace Scripts.Game
{
public interface IBonusCollected : IEventSystemHandler

{
    void OnBonusCollected(Bonuses bonus, PlayerControl player);
    void OnBonusExpired(Bonuses bonus, PlayerControl player);
        void OnPillBonusCollected(Bonuses bonus, PlayerControl player);
        void OnPillBonusExpired(Bonuses bonus, PlayerControl player);
    }
}
