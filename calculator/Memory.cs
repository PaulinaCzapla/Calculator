using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Memory
    {
        private string memory;

        public void setMemory(string otherMemory)
        {
            memory = otherMemory;
        }

        public string getMemory()
        {
            return memory;
        }

        public void AddToMemory(ref string currentOperationText)
        {
            if (memory!= string.Empty)
            {
                if (currentOperationText != string.Empty)
                {
                    if (Equation.ContainsOperation((currentOperationText[currentOperationText.Length - 1]).ToString()) || currentOperationText == string.Empty)
                    {
                        currentOperationText += memory;
                    }
                }
                else
                    currentOperationText += memory;
            }
        }

    }
}
