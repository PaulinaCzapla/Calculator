using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;


namespace calculator
{
    class Equation
    {
        private Operations operations;

        public Equation()
        {
            operations = new Operations();
        }
        public static bool ContainsOperation(string operation) => operation.Contains("-") || operation.Contains("+") || operation.Contains("^") || operation.Contains("/") || operation.Contains("*");

        public string CalculateResult(ref TextBlock currentOperationText)
        {
            if (currentOperationText.Text != string.Empty)
            {
                if (currentOperationText.Text[0] != ',')
                {
                    if (ContainsOperation((currentOperationText.Text[currentOperationText.Text.Length - 1].ToString())) || currentOperationText.Text[currentOperationText.Text.Length - 1] == ',')
                        currentOperationText.Text = currentOperationText.Text.Remove(currentOperationText.Text.Length - 1);

                    if (currentOperationText.Text.Contains("+"))
                    {
                        string[] elements = currentOperationText.Text.Split('+');
                        return operations.addition.Calculate(double.Parse(elements[0]), double.Parse(elements[1]));

                    }
                    if (currentOperationText.Text.Contains("-"))
                    {
                        string[] elements = currentOperationText.Text.Split('-');
                        return operations.subtraction.Calculate(double.Parse(elements[0]), double.Parse(elements[1]));
                    }
                    if (currentOperationText.Text.Contains("*"))
                    {
                        string[] elements = currentOperationText.Text.Split('*');
                        return operations.multiplication.Calculate(double.Parse(elements[0]), double.Parse(elements[1]));
                    }
                    if (currentOperationText.Text.Contains("^"))
                    {
                        string[] elements = currentOperationText.Text.Split('^');
                        if (elements[0] != string.Empty && elements[1] != string.Empty)
                            return operations.power.Calculate(double.Parse(elements[0]), double.Parse(elements[1]));

                    }
                    if (currentOperationText.Text.Contains("/"))
                    {
                        string[] elements = currentOperationText.Text.Split('/');
                        return operations.division.Calculate(double.Parse(elements[0]), double.Parse(elements[1]));
                    }
                    if (currentOperationText.Text.Contains("sqrt"))
                    {
                        string[] elements = currentOperationText.Text.Split("sqrt");
                        return operations.root.Calculate(double.Parse(elements[0]), 2);
                    }
                }
                else
                    currentOperationText.Text = currentOperationText.Text.Remove(0);
            }
            return currentOperationText.Text;
        }

        public bool CheckPreviousOperation(ref TextBlock resultText , ref TextBlock currentOperationText)
        {
            if (ContainsOperation(currentOperationText.Text))
            {
                string[] elements = currentOperationText.Text.Split('-', '+', '*', '^', '/');
                if (elements[elements.Length - 2] != string.Empty)
                {
                    string result = CalculateResult(ref currentOperationText);
                    if (result == "error")
                    {
                        resultText.Text = result;
                        return false;
                    }
                    else
                    {
                        currentOperationText.Text = result;
                        return true;
                    }
                }
            }
            return true;
        }

    }
}
