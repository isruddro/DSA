using System;

class Solution {
    // Structure to represent an item in the knapsack
    public struct Item {
        public int value;   // Value of the item
        public int weight;  // Weight of the item
    }

    public class KnapsackSolution {
        // Comparison function to sort the items based on their value/weight ratio
        public static int Compare(Item a, Item b) {
            double r1 = (double)a.value / (double)a.weight;
            double r2 = (double)b.value / (double)b.weight;
            if (r1 > r2) return -1; // a comes before b
            if (r1 < r2) return 1;  // b comes before a
            return 0;
        }

        // Function to find the maximum value in the fractional knapsack
        public static double FractionalKnapsack(int W, Item[] arr, int n) {
            // Sort items based on value-to-weight ratio
            Array.Sort(arr, new Comparison<Item>(Compare));

            int curWeight = 0;
            double finalValue = 0.0;

            // Loop through all the items
            for (int i = 0; i < n; i++) {
                // If the item can be fully accommodated in the knapsack
                if (curWeight + arr[i].weight <= W) {
                    curWeight += arr[i].weight;
                    finalValue += arr[i].value;
                } else {
                    // If only a fraction of the item can be accommodated
                    int remain = W - curWeight;
                    finalValue += (arr[i].value / (double)arr[i].weight) * remain;
                    break;
                }
            }

            return finalValue;
        }
    }

    static void Main(string[] args) {
        int n = 3;
        int weight = 50;
        Item[] arr = {
            new Item { value = 100, weight = 20 },
            new Item { value = 60, weight = 10 },
            new Item { value = 120, weight = 30 }
        };

        double ans = KnapsackSolution.FractionalKnapsack(weight, arr, n);
        Console.WriteLine("The maximum value is " + Math.Round(ans, 2));
    }
}
