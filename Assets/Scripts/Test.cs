using iCloudKvStore;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private InputField[] _values;
    [SerializeField] private Button _loadBtn;
    [SerializeField] private Button _saveBtn;
    [SerializeField] private Button _clearBtn;
    
    void Start()
    {
        Storage.onExternalChange += (reason, s) =>
        {
            Debug.Log($"On storage external change: {reason}, {s}; currentValue: {Storage.GetString(s)}");    
        };

        _loadBtn.onClick.AddListener(Load);
        _saveBtn.onClick.AddListener(Save);
        _clearBtn.onClick.AddListener(Clear);
    }

    void Load()
    {
        foreach (InputField field in _values)
        {
            field.text = Storage.GetString(field.name);
        }
    }

    void Save()
    {
        foreach (InputField field in _values)
        {
            bool ret = Storage.SetString(field.name, field.text);
            if (!ret)
            {
                Debug.Log($"SetString key: {field.name}, value: {field.text} failed!");
            }
        }
    }

    void Clear()
    {
        foreach (InputField field in _values)
        {
            bool ret = Storage.DeleteString(field.name);
            if (!ret)
            {
                Debug.Log($"DeleteString key: {field.name} failed!");
            }
        }
    }
}
