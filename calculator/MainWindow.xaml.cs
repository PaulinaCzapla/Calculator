using System;
using System.Windows;
using System.Collections.Generic;

namespace calculator
{
    public partial class MainWindow : Window
    {
        private Equation equation;
        private Memory memory;
        public MainWindow()
        {
            InitializeComponent();

            MathematicalOperation o;
            o = new Power();

            ResultText.Text = string.Empty;
            equation = new Equation();
            memory = new Memory();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            char currentNumber = button.Name[button.Name.Length - 1];

            Tuple<string, string> results = Tuple.Create(CurrentOperationText.Text += currentNumber, string.Empty);
            DisplayResults(results);
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults(equation.Solve("sqrt"));

            if (ResultText.Text != "error")
            {
                string text = equation.CalculateResult(CurrentOperationText.Text);

                if (text == "error")
                {
                    ResultText.Text = text;
                    CurrentOperationText.Text = string.Empty;
                }
                else
                {
                    CurrentOperationText.Text = text;
                }
            }
        }

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults(equation.Solve("^"));
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults(equation.Solve("/"));
        }

        private void ButtonSubtraction_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults(equation.Solve("-"));
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults(equation.Solve("*"));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            DisplayResults(equation.Solve("+"));
        }

        private void DisplayResults(Tuple<string, string> text)
        {
            CurrentOperationText.Text = text.Item1;
            ResultText.Text = text.Item2;
        }
        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            try
            {
                result = equation.CalculateResult(CurrentOperationText.Text);
            }
            catch (Exception er)
            {
                Console.WriteLine(er.Message);
                MessageBox.Show("Blad: " + er.Message);
            }
            memory.setMemory(result);
            Tuple<string, string> results = Tuple.Create(string.Empty, result);
            DisplayResults(results);
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
            string tmp = CurrentOperationText.Text;
            memory.AddToMemory(ref tmp);
            CurrentOperationText.Text = tmp;
        }


    }
}
