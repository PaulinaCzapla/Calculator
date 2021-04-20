using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;


namespace calculator
{
    class Equation
    {

        public static bool ContainsOperation(string operation) => operation.Contains("-") || operation.Contains("+") || operation.Contains("^") || operation.Contains("/") || operation.Contains("*");

        public static bool IsOperation(char character) => character == '-' || character == '+' || character == '^' || character == '/' || character == '*';

        public string CalculateResult(string currentOperationText)
        {

            if (currentOperationText != string.Empty)
            {
                if (currentOperationText[0] != ',')
                {
                    if (ContainsOperation((currentOperationText[currentOperationText.Length - 1].ToString())) || currentOperationText[currentOperationText.Length - 1] == ',')
                    {
                        currentOperationText = currentOperationText.Remove(currentOperationText.Length - 1);
                    }

                    string[] elements = { string.Empty, string.Empty };
                    MathematicalOperation operation = new Addition();

                    if (currentOperationText.Contains("+"))
                    {
                        operation = new Addition();
                    }
                    else if (currentOperationText.Contains("*"))
                    {
                        operation = new Multiplication();
                    }
                    else if (currentOperationText.Contains("/"))
                    {
                        operation = new Division();
                    }
                    else if (currentOperationText.Contains("^"))
                    {
                        operation = new Power();
                    }
                    else if (currentOperationText.Contains("sqrt"))
                    {
                        operation = new Root();
                    }
                    else if (currentOperationText.Contains("-"))
                    {
                        operation = new Subtraction();
                    }
                    else
                    {
                        return currentOperationText;
                    }

                    elements = operation.Parse(currentOperationText);

                    if (elements[0] != "error")
                    {
                        if (elements[0] != string.Empty && elements[1] != string.Empty)
                        {
                            return operation.Calculate(double.Parse(elements[0]), double.Parse(elements[1])).ToString();
                        }
                    }
                    else
                    {
                        return "error";
                    }
                }
                else
                {
                    currentOperationText = currentOperationText.Remove(0);
                }
            }
            return currentOperationText;
        }

        public bool CheckPreviousOperation(string currentOperationText)
        {
            if (ContainsOperation(currentOperationText))
            {
                string[] elements = null;
                elements = currentOperationText.Split('-', '+', '*', '^', '/');

                if (elements != null)
                {
                    return true;
                }
            }
            return false;
        }


        public Tuple<string, string> Solve(string operation, string currentOperationText)
        {
            string resultText = string.Empty;
            string currentOperation = currentOperationText;

            if (currentOperationText != string.Empty)
            {
                if (IsOperation(currentOperation[currentOperation.Length - 1]))
                {
                    currentOperationText = currentOperationText.Remove(currentOperation.Length - 1);
                    currentOperation = currentOperationText;
                }

                if (CheckPreviousOperation(currentOperationText))
                {
                    string text = CalculateResult(currentOperationText);

                    if (text == "error")
                    {
                        resultText = text;
                        currentOperation = string.Empty;
                    }
                    else
                    {
                        currentOperation = text;
                    }
                }
                if (resultText != "error")
                {
                    currentOperation = currentOperation + operation;
                }
            }
            else
            {
                if (operation == "-")
                {
                    currentOperation = currentOperation + operation;
                }
            }

            Tuple<string, string> result = Tuple.Create(currentOperation, resultText);
            return result;
        }

    }
}
