using System.Collections.Generic;

public interface ICollectableView
{
    bool collected { get; set; }
   
    delegate void ScorePill(bool status);
    event ScorePill eatPill;

    void BonusColored();

}
