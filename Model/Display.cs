using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator {
    class Display {
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

    }
}
