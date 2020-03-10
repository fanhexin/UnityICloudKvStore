namespace iCloudKvStore
{
    using System;
    using UnityEngine;

    /// <summary>
    ///  Used to listen for messages from the <c>CloudOnceSave</c> iOS plug-in.
    /// </summary>
    public class EventListener : MonoBehaviour
    {
        public event Action<StoreChangeReason, string> onExternalChange;
        
        /// <summary>
        /// Make sure that the object does not get destroyed if the scene changes.
        /// </summary>
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Callback method for <c>CloudOnceCloudSave</c> iOS plug-in. Name MUST be "ExternalChange".
        /// </summary>
        /// <param name="message">The callback string.</param>
        private void ExternalChange(string message)
        {
            Debug.Log($"{nameof(ExternalChange)} message: {message}==========");
            var data = message.Split('|');
            var reason = (StoreChangeReason)Enum.Parse(typeof(StoreChangeReason), data[0]);
            var devString = string.Empty;

            if (!string.IsNullOrEmpty(devString))
            {
                onExternalChange?.Invoke(reason, devString);
            }
        }
    }
}
