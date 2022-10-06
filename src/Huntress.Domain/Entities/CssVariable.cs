namespace Huntress.Domain.Entities;

public class CssVariable
{
    public Guid CssVariableId { get; private set; }
    public string Name { get; private set; } = "";
    public string Value { get; private set; } = "";

    public CssVariable(string name, string value)
    {
        Name = name;
        Value = value;
    }

    private CssVariable()
    {

    }
}
