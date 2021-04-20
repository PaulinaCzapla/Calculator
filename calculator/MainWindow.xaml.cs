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
            ResultText.Text = string.Empty;

            var button = sender as System.Windows.Controls.Button;
            char currentNumber = button.Name[button.Name.Length - 1];
            CurrentOperationText.Text += currentNumber;
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            equation.Solve("sqrt");
=======
            Solve("sqrt");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("sqrt");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("sqrt");
>>>>>>> parent of af32bab (code refactored)

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            var text = equation.Solve("^");
            CurrentOperationText.Text = text.Item1;
            ResultText.Text = text.Item2;
=======
            Solve("^");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("^");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("^");
>>>>>>> parent of af32bab (code refactored)
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            var text = equation.Solve("/");
            CurrentOperationText.Text = text.Item1;
            ResultText.Text = text.Item2;
=======
            Solve("/");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("/");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("/");
>>>>>>> parent of af32bab (code refactored)
        }

        private void ButtonSubtraction_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            var text = equation.Solve("-");
            CurrentOperationText.Text = text.Item1;
            ResultText.Text = text.Item2;
=======
            Solve("-");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("-");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("-");
>>>>>>> parent of af32bab (code refactored)
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            var text = equation.Solve("*");
=======
            Solve("*");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("*");
>>>>>>> parent of af32bab (code refactored)
=======
            Solve("*");
>>>>>>> parent of af32bab (code refactored)
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            var text = equation.Solve("+");
        }

=======
            Solve("+");
        }

=======
            Solve("+");
        }

>>>>>>> parent of af32bab (code refactored)
=======
            Solve("+");
        }

>>>>>>> parent of af32bab (code refactored)
        private void Solve(string operation)
        {
            ResultText.Text = string.Empty;

            if (equation.CheckPreviousOperation(CurrentOperationText.Text))
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
            if (ResultText.Text != "error")
            {
                CurrentOperationText.Text += operation;
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of af32bab (code refactored)
=======
>>>>>>> parent of af32bab (code refactored)
=======
>>>>>>> parent of af32bab (code refactored)
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
            ResultText.Text = result;
            memory.setMemory(result);
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
            string tmp = CurrentOperationText.Text;
            memory.AddToMemory(ref tmp);
            CurrentOperationText.Text = tmp;
        }


    }
}
