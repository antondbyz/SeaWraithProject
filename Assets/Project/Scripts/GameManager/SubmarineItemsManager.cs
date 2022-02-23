using UnityEngine;

public class SubmarineItemsManager : MonoBehaviour
{
    public static event System.Action CurrentSubmarineChanged;

    public static SubmarineItem[] SubmarineItems => _submarineItems;
    public static SubmarineItem CurrentSubmarineItem => _submarineItems[_currentSubmarineItemIndex];
    public static SubmarineItem NextSubmarineItem
    {
        get
        {
            if (_currentSubmarineItemIndex < _submarineItems.Length - 1)
            {
                return _submarineItems[_currentSubmarineItemIndex + 1];
            }
            else return null;
        }
    }
    public static int CurrentSubmarineItemIndex
    {
        get => _currentSubmarineItemIndex;
        private set
        {
            _currentSubmarineItemIndex = value;
            CurrentSubmarineChanged?.Invoke();
        }
    }

    private static SubmarineItem[] _submarineItems;
    private static int _currentSubmarineItemIndex;

    public static void SetCurrentSubmarineItemToNext()
    {
        if(_currentSubmarineItemIndex < _submarineItems.Length - 1)
        {
            CurrentSubmarineItemIndex++;
        }
    }

    private void Awake()
    {
        _submarineItems = Resources.LoadAll<SubmarineItem>("");
    }
}
