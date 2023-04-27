using UnityEngine;

public class FinishTaskTrigger : CarStopTrigger
{
    [SerializeField] private bool _destroyParent = true;

    protected override void Action(Player player)
    {
        TaskController.Instance.FinishTask();
        if(_destroyParent) Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}