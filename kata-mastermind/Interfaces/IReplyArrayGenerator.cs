namespace kata_mastermind
{
    public interface IReplyArrayGenerator
    {
        ReplyColour[] GenerateMastermindReplyArray(Colour[] inputArray, Colour[] correctArray);
    }
}