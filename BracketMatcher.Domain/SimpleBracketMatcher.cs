using System;
using System.Collections;
using System.Collections.Generic;

namespace BracketMatcher.Domain
{
    public class SimpleBracketMatcher
    {
        private char roundStartBracket = '(';
        private char roundEndBracket = ')';
        private char squareStartBracket = '[';
        private char squareEndBracket = ']';
        private char curlyStartBracket = '{';
        private char curlyEndBracket = '}';
        private List<char> braces = new List<char>();
        public int Match(string brace)
        {
            int result;
            
            braces.AddRange(brace);

            result = MatchBrackets(roundStartBracket, roundEndBracket);
            result = Math.Max(result, MatchBrackets(squareStartBracket, squareEndBracket));
            result = Math.Max(result, MatchBrackets(curlyStartBracket, curlyEndBracket));      
            
            return result;
        }

        private int MatchBrackets(char startBracket, char endBracket)
        {
            Stack bracketStack = new Stack();

            for(int i = 0; i < braces.Count; i++){
                if (braces[i] == startBracket){
                    bracketStack.Push(i);
                }else if (braces[i] == endBracket){
                    if (bracketStack.Count > 0){
                        bracketStack.Pop();
                    }else{
                        return i;
                    }
                }
            }

            if (bracketStack.Count > 0){
                return (int)(bracketStack.Peek());
            }

            return -1;
        }
    }
}
