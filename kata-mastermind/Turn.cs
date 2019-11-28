namespace kata_mastermind
{
    public class Turn
    {

        public int TurnNumber { get; set; }
        public Colour[] UserGuess { get; set; }
        public ReplyColour[] MastermindReply { get; set; }
        
        
        public Turn(int turnNumber, Colour[] userGuess, ReplyColour[] mastermindReply)
        {
            TurnNumber = turnNumber;
            UserGuess = userGuess;
            MastermindReply = mastermindReply;
        }
        
    }
}