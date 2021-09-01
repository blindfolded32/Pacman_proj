public class BonusEventTransfer
{
     public BonusEventTransfer(IBonusController bonusController, IPlayerController playerController, 
                                ICameraController cameraController,IEnemyController enemyController)
    {
        bonusController.SpeedCollect += (x) => playerController.SpeedModify((float)x);
        bonusController.SpeedCollect += (x) => cameraController.Shake();
        //
     //   bonusController.GodModeCollect += (x) => playerController.Go
     bonusController.GodModeCollect += (x) => cameraController.Shake();
    }
    
}
