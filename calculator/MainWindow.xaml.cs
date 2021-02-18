using System.Windows;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string memory;
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
            var currentNumber = button.Name[button.Name.Length -1];
            CurrentOperationText.Text += currentNumber;
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(CheckPreviousOperation(sender, e))
            CurrentOperationText.Text += "sqrt";
            
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
                string result = CalculateResult(CurrentOperationText.Text);
                if (result == "error")
                {
                    ResultText.Text = result;
                    return false;
                }
                   // ButtonResult_Click(sender, e);
                else
                    CurrentOperationText.Text = result;
                return true;
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
            string text = CurrentOperationText.Text.Remove(CurrentOperationText.Text.Length - 1);
            CurrentOperationText.Text = text;
        }

        private bool ContainsOperation(string operation) => operation.Contains("-") || operation.Contains("+") || operation.Contains("^") || operation.Contains("/") || operation.Contains("sqrt") || operation.Contains("*");
               
        private string CalculateResult(string operation)
        {
            if (operation.Contains("+"))
            {
                string [] elements = operation.Split('+');

                 if (elements[0] != string.Empty && elements[1] != string.Empty)
                 return (double.Parse(elements[0]) + double.Parse(elements[1])).ToString();
                else
                    return operation;
            }
            if (operation.Contains("-"))
            {
                string[] elements = operation.Split('-');
                if(elements[0] != string.Empty && elements[1] != string.Empty)
                    return (double.Parse(elements[0]) - double.Parse(elements[1])).ToString();
                else
                    return operation;    
            }
            if (operation.Contains("*"))
            {
                string[] elements = operation.Split('*');
                if (elements[0] != string.Empty && elements[1] != string.Empty)
                    return (double.Parse(elements[0]) * double.Parse(elements[1])).ToString();
                else
                    return operation;
            }
            if (operation.Contains("^"))
            {
                string[] elements = operation.Split('^');
                if (elements[0] != string.Empty && elements[1] != string.Empty)
                    return System.Math.Pow(double.Parse(elements[0]),double.Parse(elements[1])).ToString();
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

                if (elements[0] != string.Empty && elements[1] != string.Empty)
                { 
                    if (double.Parse(elements[1]) > 0)
                        return System.Math.Sqrt(double.Parse(elements[1])).ToString();
                }
               else
                    return "error";
                
            }

            return "error";
        }

        private void ButtonMakeDouble_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text += ",";
        }

        private void ButtonMC_Click(object sender, RoutedEventArgs e)
        {
            if (ContainsOperation((CurrentOperationText.Text[(CurrentOperationText.Text).Length - 1]).ToString()) || CurrentOperationText.Text == string.Empty)
                CurrentOperationText.Text += memory;

        }
    }
}
