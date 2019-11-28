using System;

namespace kata_mastermind
{
    class Program
    {
        
        private static readonly Colour[] AvailableColours = {Colour.Red, Colour.Blue, Colour.Green, Colour.Orange, Colour.Purple, Colour.Yellow};

        private const int MastermindArraySize = 4;

        static void Main(string[] args)
        {

            var colourArrayGenerator = new RandomColourArrayGenerator(AvailableColours, MastermindArraySize);
            
            var gameState = new GameState();
             
            var inputArrayParser = new ConsoleInputArrayParser(MastermindArraySize);
            
            var userInterface = new ConsoleUserInterface(inputArrayParser);
            
            var replyArrayGenerator = new ReplyArrayGenerator();
            
            var gameProcessor = new GameProcessor(gameState, userInterface, colourArrayGenerator, replyArrayGenerator);
            
            gameProcessor.PlayGame(20, AvailableColours);
            
        }
    }
}