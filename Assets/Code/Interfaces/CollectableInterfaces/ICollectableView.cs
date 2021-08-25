using System.Collections.Generic;

public interface ICollectableView
{
    
    delegate void ScorePill(bool status);
    event ScorePill eatPill;

    void BonusColored();

}
