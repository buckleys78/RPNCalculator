using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class Stack {
        private Stack<double> valuesStack;

        public Stack() {
            valuesStack = new Stack<double>();
        }

        public int NumberOfValues() {
            return valuesStack.Count;
        }


        public double[] PopTopTwoValues () {
            double[] pair = { 0, 0 };
            if (NumberOfValues() >= 2) {
                pair[0] = valuesStack.Pop();
                pair[1] = valuesStack.Pop();
            } else if (NumberOfValues() == 1) {
                pair[0] = valuesStack.Pop();
            }
            return pair;
        }

        public double PopTopValue () {
            double value = 0;
            if (NumberOfValues() > 0) {
                value = valuesStack.Pop();
            }
            return value;
        }

        public void Push(double value) {
            valuesStack.Push(value);
        }

        public void SwitchXandY() {
            double[] pair = PopTopTwoValues();
            valuesStack.Push(pair[0]);
            valuesStack.Push(pair[1]);
        }

        public double XValue() {
            return valuesStack.Peek();
        }
    }
}
