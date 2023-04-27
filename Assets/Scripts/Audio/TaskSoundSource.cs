using UnityEngine;

namespace DefaultNamespace.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class TaskSoundSource : MonoBehaviour
    {
        private AudioSource _source;
        
        [SerializeField] private AudioClip _taskStartedClip;
        [SerializeField] private AudioClip _taskFinishedClip;

        private void Start()
        {
            _source = GetComponent<AudioSource>();
            
            TaskController.Instance.OnTaskStarted += OnTaskStarted;
            TaskController.Instance.OnTaskFinished += OnTaskFinished;
        }

        private void OnDestroy()
        {
            TaskController.Instance.OnTaskStarted -= OnTaskStarted;
            TaskController.Instance.OnTaskFinished -= OnTaskFinished;
        }

        private void OnTaskStarted()
        {
            _source.PlayOneShot(_taskStartedClip);
        }

        private void OnTaskFinished()
        {
            _source.PlayOneShot(_taskFinishedClip);
        }
    }
}