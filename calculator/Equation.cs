using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;


namespace calculator
{
    class Equation
    {

        public static bool ContainsOperation(string operation) => operation.Contains("-") || operation.Contains("+") || operation.Contains("^") || operation.Contains("/") || operation.Contains("*");

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

                    MathematicalOperation operation = new Addition();
                    string[] elements = { string.Empty, string.Empty };

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

            if (CheckPreviousOperation(operation))
            {
                string text = CalculateResult(operation);

                if (text == "error")
                {
                    resultText = text;
                }
                else
                {
                    currentOperation = text;
                }
            }
            if (resultText != "error")
            {
                currentOperation += operation;
            }
            Tuple<string, string> result = Tuple.Create(currentOperation, resultText);
            return result;
        }

    }
}
