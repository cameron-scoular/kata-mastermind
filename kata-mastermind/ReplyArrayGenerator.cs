using System;
using System.Collections.Generic;
using System.Linq;

namespace kata_mastermind
{
    public class ReplyArrayGenerator : IReplyArrayGenerator
    {
        
        public ReplyColour[] GenerateMastermindReplyArray(Colour[] inputArray, Colour[] correctArray)
        {

            var correctMarkedArray = correctArray.Cast<Colour?>().ToArray();

            var correctColourAndPositionCount = 0;
            var correctColourWrongPositionCount = 0;

            for (var i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == correctMarkedArray[i])
                {
                    correctColourAndPositionCount++;
                    correctMarkedArray[i] = null;
                }else if (correctMarkedArray.Contains(inputArray[i]))
                {
                    correctColourWrongPositionCount++;
                    correctMarkedArray[Array.IndexOf(correctMarkedArray, inputArray[i])] = null;
                }
            }

            return CreateShuffledReplyArray(correctColourAndPositionCount, correctColourWrongPositionCount);

        }

        private ReplyColour[] CreateShuffledReplyArray(int correctColourAndPositionCount, int correctColourWrongPositionCount)
        {
            var replyColourArray = new ReplyColour[correctColourAndPositionCount + correctColourWrongPositionCount];

            for (var i = 0; i < correctColourAndPositionCount; i++)
            {
                replyColourArray[i] = ReplyColour.Black;
            }
            
            for(var i = correctColourAndPositionCount; i < correctColourWrongPositionCount; i++)
            {
                replyColourArray[i] = ReplyColour.White;
            }

            return replyColourArray;
        }
        
    }
}