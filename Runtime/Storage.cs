using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace iCloudKvStore
{

    /// <summary>
    ///  Provides a bridge between C# code and the <c>CloudOnceSave</c> iOS plug-in.
    /// </summary>
    public static class Storage
    {
        private const string c_importInternal = "__Internal";
        
        public static event Action<StoreChangeReason, string> onExternalChange
        {
            add => _eventListener.onExternalChange += value;
            remove => _eventListener.onExternalChange -= value;
        }
        
        private static EventListener __eventListener;
        private static EventListener _eventListener
        {
            get
            {
                if (__eventListener != null)
                {
                    return __eventListener;
                }
                
                var go = new GameObject("iCloudKvStoreListener");
                return go.AddComponent<EventListener>();
            }
        }

        public static bool enabled => _IsiCloudEnabled();

        /// <summary>
        /// Stores a <see cref="string"/> in iCloud.
        /// </summary>
        /// <param name="key">The unique identifier for this <see cref="string"/>.</param>
        /// <param name="value">The <see cref="string"/> to store in iCloud.</param>
        /// <returns>
        /// Returns <c>true</c> if the <see cref="string"/> was successfully saved to iCloud, <c>false</c> if any problems happened.
        /// </returns>
        public static bool SetString(string key, string value)
        {
            return _SetDevString(key, value);
        }

        /// <summary>
        /// Gets a <see cref="string"/> from iCloud.
        /// </summary>
        /// <param name="key">The unique identifier for the <see cref="string"/>.</param>
        /// <returns>The <see cref="string"/> associated with the specified key.</returns>
        public static string GetString(string key)
        {
            return _GetDevString(key);
        }

        /// <summary>
        /// Deletes a <see cref="string"/> from iCloud.
        /// </summary>
        /// <param name="key">The unique identifier for the <see cref="string"/>.</param>
        /// <returns>
        /// Returns <c>true</c> if the <see cref="string"/> was successfully deleted from iCloud, <c>false</c> if any problems happened.
        /// </returns>
        public static bool DeleteString(string key)
        {
            return _DeleteDevString(key);
        }

        [DllImport(c_importInternal)]
        private static extern bool _SetDevString(string key, string value);

        [DllImport(c_importInternal)]
        private static extern string _GetDevString(string key);

        [DllImport(c_importInternal)]
        private static extern bool _DeleteDevString(string key);
        
        [DllImport(c_importInternal)]
        private static extern bool _IsiCloudEnabled();
    }
}
