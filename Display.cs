using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator {
    class Display {
        public int FixedDecimalDigitsToDisplay { get; set; }
        public bool IsFixedDecimal { get; set; }

        public string ValueToShow(double rawValue) {
            if (IsFixedDecimal) {
                return string.Format("0.000", rawValue);
            } else {
                return rawValue.ToString();
            }
        }

    }
}
