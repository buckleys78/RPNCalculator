using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class Operators {
        public static double Add(double val1, double val2) {
            return val1 + val2;
        }

        public static double Sub(double val1, double val2) {
            return val1 - val2;
        }

        public static double Mul(double val1, double val2) {
            return val1 * val2;
        }

        public static double Div(double val1, double val2) {
            return val1 / val2;
        }
    }
}
