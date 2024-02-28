class NamesValidator
{
    public bool IsValid(string name)
    {
        return name.All(char.IsLetter) && name.Length >= 2 && name.Length< 25 && char.IsUpper(name[0]);
    }
}

