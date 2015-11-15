using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class Operators {

        public static double AddXandY(double[] XYValues) {
            return XYValues[1] + XYValues[0];
        }
        
        public static double DivideYbyX(double[] XYValues) {
            return XYValues[1] / XYValues[0];
        }

        public static double MultiplyXandY(double[] XYValues) {
            return XYValues[1] * XYValues[0];
        }

        public static double PowerYtoTheX(double[] XYValues) {
            return Math.Pow(XYValues[1], XYValues[0]);
        }

        public static double RepricalOfX(double X) {
            return 1 / X;
        }

        public static double SubtractXfromY(double[] XYValues) {
            return XYValues[1] - XYValues[0];
        }
    }
}
