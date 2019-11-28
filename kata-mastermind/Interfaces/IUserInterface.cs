using System.Collections.Generic;

namespace kata_mastermind
{
    public interface IUserInterface
    {

        void DisplayTurnHistory(List<Turn> turnHistory);

        Colour[] PromptUserForColourArrayGuess(int arrraySize, Colour[] availableColours);

        void DisplayMastermindReplyArray(ReplyColour[] replyArray);

        void DisplayTurnNumber(int turnNumber);

        void WinGame();
        void LoseGame();

    }
}