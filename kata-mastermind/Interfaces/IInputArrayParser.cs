namespace kata_mastermind
{
    public interface IInputArrayParser
    {
        Colour[] ParseInputArrayString(string input);
    }
}