using System;

namespace kata_mastermind
{
    public class ConsoleInputArrayParser : IInputArrayParser
    {

        public int ArraySize { get; private set; }

        public ConsoleInputArrayParser(int arraySize)
        {
            ArraySize = arraySize;
        }
        
        public Colour[] ParseInputArrayString(string inputString)
        {

            var colourArray = new Colour[ArraySize];

            var inputWordArray = inputString.Split(" ");

            if (inputWordArray.Length > ArraySize)
            {
                throw new ArgumentException($"Error: you must pass {ArraySize} colours");
            }
            
            for(var i = 0; i < ArraySize; i++)
            {
                try
                {
                    colourArray[i] = ParseColour(inputWordArray[i]);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ArgumentException("Error: you must provide 4 colours");
                }
            }

            return colourArray;

        }

        private static Colour ParseColour(string inputString)
        {
            try
            {
                var colour = Enum.Parse(typeof(Colour), inputString, true);
                return (Colour) colour;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Error: you have given an invalid colour");
            }
            
        }
    }
}