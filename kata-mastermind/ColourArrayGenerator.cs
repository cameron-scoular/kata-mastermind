using System;

namespace kata_mastermind
{
    public class RandomColourArrayGenerator : IColourArrayGenerator
    {
        Random RandomGenerator = new Random();

        private Colour[] AvailableColours;

        private int ArraySize;

        public RandomColourArrayGenerator(Colour[] availableColours, int newArraySize)
        {
            AvailableColours = availableColours;
            ArraySize = newArraySize;
        }
        
        public Colour[] GenerateNewColourArray()
        {

            var newColourArray = new Colour[ArraySize];

            for (var i = 0; i < ArraySize; i++)
            {
                var randomIndex = RandomGenerator.Next(0, AvailableColours.Length - 1);
                newColourArray[i] = AvailableColours[randomIndex];
            }

            return newColourArray;

        }
    }
}