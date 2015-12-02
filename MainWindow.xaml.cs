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

            EventManager.RegisterClassHandler(typeof(Window), Keyboard.KeyUpEvent, new KeyEventHandler(keyUp), true);
            MemoryStack = new Values();
            InitializeComponent();
            InitializeCalculationMode();
            UpdateDisplays();
        }

        private void InitializeCalculationMode() {
            CalculatorMode = new CalculationMode(modeOnStartup: CalcMode.RPN);
            rbSelectRPN.IsChecked = CalculatorMode.CurrentMode == CalcMode.RPN;
            rbSelectTI.IsChecked = !rbSelectRPN.IsChecked;
            UpdateCalculationMode();
        }

        private CalculationMode CalculatorMode { get; set; }
        private Values MemoryStack { get; set; }

        private void UpdateDisplays() {
            if (MemoryStack.xRegister.BufferIsEmpty()) {
                displayField.Text = MemoryStack.TopValue().ToString();
            } else {
                displayField.Text = MemoryStack.xRegister.NewEntryBuffer;
            }
            lboxMemoryStack.ItemsSource = MemoryStack.listOfStackedValues();
        }

        // Keyboard
        private void keyUp(object sender, KeyEventArgs e) {
            string digitKey = digitFromKey(e.Key.ToString());

            MessageBox.Show(e.Key.ToString());
            var isShift = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
            var isCtrl = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
            var isAlt = Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt);
            if (!isShift) {
                MemoryStack.xRegister.AddDigit(digitKey);
            } else {
                switch (e.Key.ToString()) {
                    case "OemPlus":

                    case "OemMinus":

                    case "OemQuestion":

                    case "OemPeriod":

                    default:
                        break;
                }
            }
            UpdateDisplays();
        }

        private string digitFromKey(string keyCode) {
            string digit = "";
            if(keyCode.Length == 2 && keyCode.StartsWith("D") && char.IsDigit(keyCode,1)) {
                digit = keyCode.Substring(keyCode.Length - 1, 1);
            }
            return digit;
        }

        // Operator Keys
        private void processOperatorButtonClick(object sender) {
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
                MemoryStack.xRegister.ClearBuffer();
                UpdateDisplays();
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
                MemoryStack.xRegister.AddDigit(block.Content.ToString());
                UpdateDisplays();
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

        private void btnChangeSign_Click(object sender, RoutedEventArgs e) {
            processNmbrButtonClick(sender);
        }

        // Stack Manipulation
        private void btnSwitchXandY_Click(object sender, RoutedEventArgs e) {
            MemoryStack.SwitchXandY();
            UpdateDisplays();
        }

        // Display Control
        private void btnClearDisplay_Click(object sender, RoutedEventArgs e) {
            MemoryStack.xRegister.ClearBuffer();
            UpdateDisplays();
        }

        private void btnBackSpace_Click(object sender, RoutedEventArgs e) {
            MemoryStack.xRegister.DeleteLastDigit();
            UpdateDisplays();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e) {
            MemoryStack.xRegister.PushBufferUpTheStack();
            MemoryStack.xRegister.XRegisterIsPlaceholder = true;
            UpdateDisplays();
        }

        // Calculation Mode
        private void UpdateCalculationMode() {

            if (rbSelectRPN != null && CalculatorMode != null && btnEnter != null && btnEqualSign != null) {
                if (rbSelectRPN.IsChecked == true) {
                    CalculatorMode.CurrentMode = CalcMode.RPN;
                    btnEnter.Visibility = System.Windows.Visibility.Visible;
                    btnEqualSign.Visibility = System.Windows.Visibility.Hidden;
                } else {
                    CalculatorMode.CurrentMode = CalcMode.TI;
                    btnEnter.Visibility = System.Windows.Visibility.Hidden;
                    btnEqualSign.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void rbSelectRPN_Checked(object sender, RoutedEventArgs e) {
            UpdateCalculationMode();
        }

        private void rbSelectTI_Checked(object sender, RoutedEventArgs e) {
            UpdateCalculationMode();
        }

        
    }
}
