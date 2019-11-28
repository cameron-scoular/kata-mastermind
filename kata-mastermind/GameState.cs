using System.Collections.Generic;

namespace kata_mastermind
{
    public class GameState
    {
        public Colour[] CorrectColourArray { get; private set; }
        
        public Colour[] AvailableColours { get; private set; }

        public int ArraySize => CorrectColourArray.Length;
        
        public int TurnNumber { get; private set; }
        
        public int MaxTurnNumber { get; private set; }
        
        
        public List<Turn> TurnHistory { get; private set; }

        public bool GameIsActive => TurnNumber <= MaxTurnNumber;

        public void ResetGameState(IColourArrayGenerator colourArrayGenerator, int maxTurnNumber, Colour[] availableColours)
        {
            CorrectColourArray = colourArrayGenerator.GenerateNewColourArray();
            TurnNumber = 1;
            MaxTurnNumber = maxTurnNumber;
            TurnHistory = new List<Turn>();
            AvailableColours = availableColours;
        }

        public void IncrementTurnNumber()
        {
            TurnNumber++;
        }

        public void AddTurnToHistory(Turn turn)
        {
            TurnHistory.Add(turn);
        }

        
    }
}