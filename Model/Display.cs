using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class Display {
        // private string defaultDisplay = "0.";
        public string Buffer { get; set; }

        public int FixedDecimalDigitsToDisplay { get; set; }

        public bool HasDecimalPoint() {
            return Buffer.Contains(".");
        }

        public bool IsFixedDecimal { get; set; }

        public string ValueToShow(double rawValue) {
            if (IsFixedDecimal) {
                return string.Format("0.000", rawValue);
            } else {
                return rawValue.ToString();
            }
        }

        // Constructors
        public Display() {
            //Buffer = defaultDisplay;
        }

        // Methods/Functions
        public string AddDigitToBuffer(string digit) {
            if (digit == "." && HasDecimalPoint()) {
                return Buffer;
            } else {
                return Buffer += digit;
            }
        }

        public void ClearBuffer() {
            Buffer = "";
        }

        public void DeleteLastDigit() {
            if (Buffer.Length > 0) {
                Buffer = Buffer.Substring(0, Buffer.Length - 1);
            }
        }

        public void PushToStack(Stack memStack) {
            double displayValue;
            if (Double.TryParse(Buffer, out displayValue)) {
                memStack.Push(displayValue);
            }
            ClearBuffer();
        }
    }
}
