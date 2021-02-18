﻿using System.Windows;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static private string memory;
        public MainWindow()
        {
            InitializeComponent();
            memory = string.Empty;
            ResultText.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;

            var button = sender as System.Windows.Controls.Button;
            char currentNumber = button.Name[button.Name.Length -1];
            CurrentOperationText.Text += currentNumber;
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            {
                string operation = CurrentOperationText.Text + "sqrt";
                CurrentOperationText.Text = CalculateResult(operation);
            }
        }

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            CurrentOperationText.Text += "^";
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            CurrentOperationText.Text += "/";
        }

        private void ButtonSubtraction_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            CurrentOperationText.Text += "-";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            CurrentOperationText.Text += "*";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            CurrentOperationText.Text += "+";
        }

     private bool CheckPreviousOperation(object sender, RoutedEventArgs e)
        {
            if (ContainsOperation(CurrentOperationText.Text))
            {
                string[] elements = CurrentOperationText.Text.Split('-','+','*','^','/');   
                if (elements[elements.Length - 2] != string.Empty)
                {
                    string result = CalculateResult(CurrentOperationText.Text);
                    if (result == "error")
                    {
                        ResultText.Text = result;
                        return false;
                    }
                    else
                        CurrentOperationText.Text = result;
                    return true;
                }
            }
            return true;
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;    
            string result = CalculateResult(operation);
            ResultText.Text = result;
            memory = result;
            CurrentOperationText.Text = string.Empty;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperationText.Text != string.Empty)
            {
                string text = CurrentOperationText.Text.Remove(CurrentOperationText.Text.Length - 1);
                CurrentOperationText.Text = text;
            }
        }


        private void ButtonMakeDouble_Click(object sender, RoutedEventArgs e) => CurrentOperationText.Text += ",";
        

        private void ButtonMC_Click(object sender, RoutedEventArgs e)
        {
            if (memory != string.Empty)
            {
                if (CurrentOperationText.Text != string.Empty)
                {
                    if (ContainsOperation((CurrentOperationText.Text[(CurrentOperationText.Text).Length - 1]).ToString()) || CurrentOperationText.Text == string.Empty)
                        CurrentOperationText.Text += memory;
                }
                else
                    CurrentOperationText.Text += memory;
            }
        }

        private bool ContainsOperation(string operation) => operation.Contains("-") || operation.Contains("+") || operation.Contains("^") || operation.Contains("/") || operation.Contains("*");
               
        private string CalculateResult(string operation)
        {       
            if (operation != string.Empty)
            {
                if (operation[0] != ',')
                {
                    if (ContainsOperation((operation[operation.Length - 1].ToString())) || operation[operation.Length - 1] == ',')
                        operation = operation.Remove(operation.Length - 1);

                    if (operation.Contains("+"))
                    {
                        string[] elements = operation.Split('+');

                        if (elements[0] != string.Empty && elements[1] != string.Empty)
                            return (double.Parse(elements[0]) + double.Parse(elements[1])).ToString();
                        else
                            return "error";
                    }
                    if (operation.Contains("-"))
                    {
                        string[] elements = operation.Split('-');
                        if (elements[0] != string.Empty && elements[1] != string.Empty)
                            return (double.Parse(elements[0]) - double.Parse(elements[1])).ToString();
                        else
                            return "error";
                    }
                    if (operation.Contains("*"))
                    {
                        string[] elements = operation.Split('*');
                        if (elements[0] != string.Empty && elements[1] != string.Empty)
                            return (double.Parse(elements[0]) * double.Parse(elements[1])).ToString();
                        else
                            return "error";
                    }
                    if (operation.Contains("^"))
                    {
                        string[] elements = operation.Split('^');
                        if (elements[0] != string.Empty && elements[1] != string.Empty)
                            return System.Math.Pow(double.Parse(elements[0]), double.Parse(elements[1])).ToString();
                        else
                            return "error";
                    }
                    if (operation.Contains("/"))
                    {
                        string[] elements = operation.Split('/');
                        if (double.Parse(elements[1]) != 0)
                            if (elements[0] != string.Empty && elements[1] != string.Empty)
                            {
                                return (double.Parse(elements[0]) / double.Parse(elements[1])).ToString();
                            }
                            else return operation;
                        else return "error";
                    }
                    if (operation.Contains("sqrt"))
                    {
                        string[] elements = operation.Split("sqrt");

                        if (elements[0] != string.Empty)
                        {
                            if (double.Parse(elements[0]) >= 0)
                                return System.Math.Sqrt(double.Parse(elements[0])).ToString();
                        }
                        else
                            return "error";
                    }
                }
                else
                    operation = operation.Remove(0);
            }
            return operation;
        }
    }
}