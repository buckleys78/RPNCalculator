using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Model {
    class Values {
        private Stack<double> StackedValues;
        public XRegister xRegister { get; set; }

        // Constructor(s)
        public Values() {
            StackedValues = new Stack<double>();
            xRegister = new XRegister(this);
        }

        // Methods/Functions
        public List<string> listOfStackedValues() {
            //return new List<double>(StackedValues).Select(x => x.ToString()).ToList();
            var stackList = new List<string>();
            foreach (var value in StackedValues) {
                string s = "";
                if (double.IsNegativeInfinity(value)) {
                    s = "-Inf";
                } else if (double.IsPositiveInfinity(value)) {
                    s = "+Inf";
                } else {
                    s = value.ToString();
                }
                stackList.Add(s);
            }
            return stackList;
        }

        public int NumberOfValues() {
            return StackedValues.Count;
        }

        public double[] PopTopTwoValues () {
            double[] pair = { 0, 0 };
            if (NumberOfValues() >= 2) {
                pair[0] = StackedValues.Pop();
                pair[1] = StackedValues.Pop();
            } else if (NumberOfValues() == 1) {
                pair[0] = StackedValues.Pop();
            }
            return pair;
        }

        public double PopTopValue() {
            double value = 0;
            if (NumberOfValues() > 0) {
                value = StackedValues.Pop();
            }
            return value;
        }

        public void Push(double value) {
            StackedValues.Push(value);
        }

        public void RollDown() {
            xRegister.ClearBuffer();
            if (NumberOfValues() < 2) return;
            var tempStack = new Stack<double>();
            var newStack = new Stack<double>();
            newStack.Push(StackedValues.Pop());
            while (NumberOfValues() > 0) {
                tempStack.Push(StackedValues.Pop());
            }
            while (tempStack.Count > 0) {
                newStack.Push(tempStack.Pop());
            }
            StackedValues = newStack;
        }

        public void SwitchXandY() {
            xRegister.ClearBuffer();
            double[] pair = PopTopTwoValues();
            StackedValues.Push(pair[0]);
            StackedValues.Push(pair[1]);
        }

        public double TopValue() {
            if (NumberOfValues() > 0) {
                return StackedValues.Peek();
            } else {
                return 0.0;
            }
        }

        public void UpdateTopValue(double newValue) {
            double oldValue = PopTopValue();
            Push(newValue);
        }
    }
}
