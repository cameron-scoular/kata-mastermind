using System.Linq;

namespace kata_mastermind
{
    public class GameProcessor
    {
        private GameState GameState { get; set; }
        private IUserInterface UserInterface { get; set; }
        private IColourArrayGenerator ColourArrayGenerator { get; set; }
        private IReplyArrayGenerator ReplyArrayGenerator { get; set; }

        public GameProcessor(GameState gameState, IUserInterface userInterface,
            IColourArrayGenerator colourArrayGenerator, IReplyArrayGenerator replyArrayGenerator)
        {
            GameState = gameState;
            UserInterface = userInterface;
            ColourArrayGenerator = colourArrayGenerator;
            ReplyArrayGenerator = replyArrayGenerator;
        }

        public void PlayGame(int maxTurnNumber, Colour[] availableColours)
        {
            
            GameState.ResetGameState(ColourArrayGenerator, maxTurnNumber, availableColours);

            while (GameState.GameIsActive)
            {

                if (GameState.TurnNumber != 1)
                {
                    UserInterface.DisplayTurnHistory(GameState.TurnHistory);
                }
                
                UserInterface.DisplayTurnNumber(GameState.TurnNumber);

                var userGuessColourArray = UserInterface.PromptUserForColourArrayGuess(GameState.ArraySize, availableColours);

                var mastermindReply =
                    ReplyArrayGenerator.GenerateMastermindReplyArray(userGuessColourArray, GameState.CorrectColourArray);
                
                UserInterface.DisplayMastermindReplyArray(mastermindReply);


                GameState.AddTurnToHistory(new Turn(GameState.TurnNumber, userGuessColourArray, mastermindReply));
                GameState.IncrementTurnNumber();
                
                CheckEndGameConditions(mastermindReply);

            }
            
        }
        
        private void CheckEndGameConditions(ReplyColour[] replyColours)
        {
            if (replyColours.Length == GameState.ArraySize && !replyColours.Contains(ReplyColour.White))
            {
                UserInterface.WinGame();
            }

            if (GameState.GameIsActive == false)
            {
                UserInterface.LoseGame();
            }
        }

    }
}