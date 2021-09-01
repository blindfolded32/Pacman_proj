using static UnityEngine.Object;
using UnityEngine.AI;

public class EnemyController : IEnemyController
{
    public NavMeshAgent NavMeshAgent { get; private set; }

    private IEnemyModel _enemyModel;
    private IEnemyView _enemyView;

    public EnemyController(IEnemyModel enemyModel, IBonusController bonusController)
    {
        EnemyView[] enemies = FindObjectsOfType<EnemyView>();
        
        foreach(var enemy in enemies)
        {
        _enemyModel = enemyModel;
        _enemyView = enemy;
        bonusController.GodModeCollect += (x) => Flee((bool)x);

        }
    }


    private void Flee(bool status)
    {

    }
    public void OnUpdate()
    {
        NavMeshAgent.destination = FindObjectOfType<PlayerView>().transform.position;
    }
}
