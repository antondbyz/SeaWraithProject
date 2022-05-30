[System.Serializable]
public struct Locale
{
    [System.Serializable]
    public struct Data
    {
        public string Key;
        public string Value;
    }
    public Data[] LocaleData;
}
