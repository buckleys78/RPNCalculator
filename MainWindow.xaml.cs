using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPNCalculator.Model;
using RPNCalculator.View.NumericKeys;

namespace RPNCalculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        public MainWindow() {
            //InitializeCalculationMode();
            CalculatorMode = new CalculationMode();
            CalculatorMode.CurrentMode = CalcMode.RPN;
            
            InitializeComponent();
            btnEnter.Visibility = Visibility.Visible;
            btnEqualSign.Visibility = Visibility.Hidden;

            MemoryStack = new StackOfValues();
            
            CalculatorDisplay = new Display();
            UpdateDisplay();
        }

        private void InitializeCalculationMode() {
            CalculatorMode = new CalculationMode();
            //rbSelectRPN.IsChecked = CalculatorMode.CurrentMode == CalcMode.RPN;
            //rbSelectTI.IsChecked = !rbSelectRPN.IsChecked;
            //rbSelectRPN.IsChecked = true;
            //rbSelectTI.IsChecked = false;
            UpdateCalculationMode();
        }

        private Display CalculatorDisplay { get; set; }
        private CalculationMode CalculatorMode { get; set; }
        private StackOfValues MemoryStack { get; set; }

        private void UpdateDisplay(double? newDisplayValue = null) {
            if (newDisplayValue.HasValue) {
                displayField.Text = newDisplayValue.ToString();
            } else {
                displayField.Text = CalculatorDisplay.Buffer;
            }

            lboxMemoryStack.ItemsSource = MemoryStack.ListOfStackValues();
        }

        // Operator Keys
        private void processOperatorButtonClick(object sender) {
            CalculatorDisplay.PushToStack(MemoryStack);
            var block = sender as Button;
            double result = 0;
            if (block != null) {
                double[] XYpair = MemoryStack.PopTopTwoValues();
                switch (block.Name) {
                    case "btnSubtract":
                        result = Operators.SubtractXfromY(XYpair);
                        break;
                    case "btnAdd":
                        result = Operators.AddXandY(XYpair);
                        break;
                    case "btnDivide":
                        result = Operators.DivideYbyX(XYpair);
                        break;
                    case "btnMultiply":
                        result = Operators.MultiplyXandY(XYpair);
                        break;
                    case "btnPowerOfX":
                        result = Operators.PowerYtoTheX(XYpair);
                        break;
                    case "btnReciprocalOfX":
                        MemoryStack.Push(XYpair[1]);
                        result = Operators.RepricalOfX(XYpair[0]);
                        break;
                }
                MemoryStack.Push(result);
                UpdateDisplay(result);
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e) {
            processOperatorButtonClick(sender);
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e) {
            processOperatorButtonClick(sender);
        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e) {
            processOperatorButtonClick(sender);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            processOperatorButtonClick(sender);
        }

        private void btnEqualSign_Click(object sender, RoutedEventArgs e) {

        }

        // Numeric Keypad 
        private void processNmbrButtonClick(object sender) {
            var block = sender as Button;
            if (block != null) {
                CalculatorDisplay.AddDigitToBuffer(block.Content.ToString());
                UpdateDisplay();
            }
        }

        private void btnNmbr0_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr1_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr2_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr3_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr4_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr5_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr6_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr7_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr8_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnNmbr9_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        private void btnDecimalPoint_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        // Stack Manipulation
        private void btnSwitchXandY_Click(object sender, RoutedEventArgs e) {
            MemoryStack.SwitchXandY();
        }

        // Display Control
        private void btnClearDisplay_Click(object sender, RoutedEventArgs e) {
            CalculatorDisplay.ClearBuffer();
            UpdateDisplay();
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
            CalculatorDisplay.DeleteLastDigit();
            UpdateDisplay();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e) {
            CalculatorDisplay.PushToStack(MemoryStack);
            UpdateDisplay();
        }

        // Calculation Mode
        private void UpdateCalculationMode() {
            /*if (!rbSelectRPN.HasContent) {
                rbSelectRPN.IsChecked = true;
            }
            if (rbSelectRPN.IsChecked == true) {
                CalculatorMode.CurrentMode = CalcMode.RPN;
                btnEnter.Visibility = System.Windows.Visibility.Visible;
                btnEqualSign.Visibility = System.Windows.Visibility.Hidden;
            } else {
                CalculatorMode.CurrentMode = CalcMode.TI;
                btnEnter.Visibility = System.Windows.Visibility.Hidden;
                btnEqualSign.Visibility = System.Windows.Visibility.Visible;
            }
            */
        }

        private void rbSelectRPN_Checked(object sender, RoutedEventArgs e) {
            UpdateCalculationMode();
        }

        private void rbSelectTI_Checked(object sender, RoutedEventArgs e) {
            UpdateCalculationMode();
        }
    }
}
