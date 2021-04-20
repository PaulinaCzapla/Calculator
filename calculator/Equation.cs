﻿using System;
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
            MathematicalOperation operation = new Addition();
            if (currentOperationText != string.Empty)
            {
                if (currentOperationText[0] != ',')
                {
                    if (ContainsOperation((currentOperationText[currentOperationText.Length - 1].ToString())) || currentOperationText[currentOperationText.Length - 1] == ',')
                    {
                        currentOperationText = currentOperationText.Remove(currentOperationText.Length - 1);
                    }

                    string[] elements = { string.Empty, string.Empty };

                    if (currentOperationText.Contains("+"))
                    {
                        elements = currentOperationText.Split('+');
                        operation = new Addition();
                    }
                    else if (currentOperationText.Contains("*"))
                    {
                        elements = currentOperationText.Split('*');
                        operation = new Multiplication();
                    }
                    else if (currentOperationText.Contains("/"))
                    {
                        elements = currentOperationText.Split('/');

                        if (elements[1] == "0")
                            return "error";

                        operation = new Division();
                    }
                    else if (currentOperationText.Contains("^"))
                    {
                        elements = currentOperationText.Split('^');
                        operation = new Power();
                    }
                    else if (currentOperationText.Contains("sqrt"))
                    {
                        elements = currentOperationText.Split("sqrt");

                        if (elements[0][0] == '-')
                            return "error";

                        operation = new Root();

                        return operation.Calculate(double.Parse(elements[0]), 2).ToString();

                    } else if (currentOperationText.Contains("-"))
                    {
                        elements = currentOperationText.Split('-');
                        operation = new Subtraction();
                    }
                    if (elements[0] != string.Empty && elements[1] != string.Empty)
                        return operation.Calculate(double.Parse(elements[0]), double.Parse(elements[1])).ToString();
                }
                else
                    currentOperationText = currentOperationText.Remove(0);
            }
            return string.Empty;
        }

        public bool CheckPreviousOperation(ref TextBlock resultText, ref TextBlock currentOperationText)
        {
            if (ContainsOperation(currentOperationText.Text))
            {
                string[] elements = currentOperationText.Text.Split('-', '+', '*', '^', '/');
                if (elements[elements.Length - 2] != string.Empty)
                {
                    string result = CalculateResult(currentOperationText.Text);
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
