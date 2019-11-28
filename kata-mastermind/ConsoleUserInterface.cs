using System;
using System.Collections.Generic;
using System.Text;

namespace kata_mastermind
{
    public class ConsoleUserInterface : IUserInterface
    {
        
        public IInputArrayParser InputArrayParser { get; private set; }
        
        public ConsoleUserInterface(IInputArrayParser inputArrayParser)
        {
            InputArrayParser = inputArrayParser;
        }

        public void DisplayTurnHistory(List<Turn> turnHistory)
        {
            WriteConsoleDividerLine();
            Console.WriteLine("Your turn history:");

            foreach (var turn in turnHistory)
            {
                var turnStringEntry = new StringBuilder();
                
                turnStringEntry.Append($"Turn {turn.TurnNumber} | [ ");
                
                foreach (var colour in turn.UserGuess)
                {
                    turnStringEntry.Append($"{colour} ");
                }

                turnStringEntry.Append("] | [");

                foreach (var replyColour in turn.MastermindReply)
                {
                    turnStringEntry.Append($"{replyColour} ");
                }

                turnStringEntry.Append("]");
                Console.WriteLine(turnStringEntry);

            }

            WriteConsoleDividerLine();
        }

        public void DisplayAvailableColours(Colour[] availableColours)
        {
            var availableColourStringBuilder = new StringBuilder();
            availableColourStringBuilder.Append("Available Colours: ");

            foreach (var colour in availableColours)
            {
                availableColourStringBuilder.Append($"{colour} ");
            }
            
            Console.WriteLine(availableColourStringBuilder);
        }

        public Colour[] PromptUserForColourArrayGuess(int arraySize, Colour[] availableColours)
        {
            DisplayAvailableColours(availableColours);

            while (true)
            {
                Console.WriteLine($"Please enter your {arraySize} colour guess e.g. 'Red Blue Green Yellow':");

                var userInput = Console.ReadLine();

                try
                {
                    return InputArrayParser.ParseInputArrayString(userInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            

        }

        public void DisplayTurnNumber(int turnNumber)
        {
            Console.WriteLine($"Now beginning turn {turnNumber}...");
        }

        public void DisplayMastermindReplyArray(ReplyColour[] replyArray)
        {
            
            var replyStringBuilder = new StringBuilder();
            replyStringBuilder.Append("Mastermind Response: [ ");

            foreach (var replyColour in replyArray)
            {
                replyStringBuilder.Append($"{replyColour} ");
            }

            replyStringBuilder.Append(" ]");
            
            Console.WriteLine(replyStringBuilder);

        }

        public void WinGame()
        {
            Console.WriteLine("You have won the game!");
        }

        public void LoseGame()
        {
            Console.WriteLine("You have run out of turns and lost the game");
        }

        private void WriteConsoleDividerLine()
        {
            Console.WriteLine("---------------------------------------------------");
        }
    }
}