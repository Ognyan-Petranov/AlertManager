using System.Collections.Generic;
using AlertManager.Application.Interfaces;

namespace AlertManager.Application.Features.ValidationService
{
    public class ValidationService : IValidationService
    {
        public bool Validate(string expression)
        {
            var bracketsStack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                var currentChar = expression[i];
                if ((currentChar == ')' || currentChar == ']') && bracketsStack.Count == 0)
                {
                    return false;
                }
                else if (currentChar == '(' || currentChar == '[')
                {
                    bracketsStack.Push(currentChar);
                }
                else if (currentChar == ')' && bracketsStack.Peek() == '(' || currentChar == ']' && bracketsStack.Peek() == '[')
                {
                    bracketsStack.Pop();
                }
            }

            if (bracketsStack.Count > 0)
            {
                return false;
            }

            return true;
        }
    }
}
