using UnityEngine;

public class StartTaskTrigger : CarStopTrigger
{
    [SerializeField] private bool _destroyParent = true;
    
    protected override void Action(Player player)
    {
        TaskController.Instance.StartTask();
        if(_destroyParent) Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}