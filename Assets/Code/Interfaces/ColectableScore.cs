
    public class ColectableScore
    {
        public ColectableScore(ICollectableController collectableController, IBonusController bonusController, IScore score)
        {
            collectableController.CollectPill +=  score.ScoreIncrease;
            bonusController.ScoreCollect += (x) => score.ChangeMulti((float)x);
        }
    }
