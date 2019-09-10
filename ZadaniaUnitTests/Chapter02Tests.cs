using System.Collections;
using NUnit.Framework;

namespace Tests
{
    public class Chapter02Tests
    {
        class Zadanie01Permutacja
        {
            public static bool Solution(int n, int[] A)
            {
                var exists = new bool[n];
                for (int i = 0; i < n; i++)
                {
                    if (exists[A[i] - 1]) return false;
                    exists[A[i] - 1] = true;
                }

                return true;
            }

            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(5, new[] { 1, 4, 3, 2, 5 }).Returns(true);
                    yield return new TestCaseData(5, new[] { 1, 4, 3, 3, 5 }).Returns(false);
                }
            }
        }

        [TestCaseSource(typeof(Zadanie01Permutacja), nameof(Zadanie01Permutacja.TestCases))]
        public bool Zadanie01PermutacjaTest(int n, int[] A)
        {
            return Zadanie01Permutacja.Solution(n, A);
        }

        class Zadanie02Ropucha
        {
            public static int Solution(int target, int n, int[] A)
            {
                var targetSum = (target * (target + 1)) / 2;
                var exists = new bool[target];

                for (int i = 0; i < n; i++ )
                {
                    int leaf = A[i];
                    if (leaf > target) continue;
                    if (exists[leaf - 1]) continue;
                    exists[leaf - 1] = true;
                    targetSum = targetSum - leaf;
                    if (targetSum == 0) return i + 1;
                }

                return -1;
            }

            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new[] { 5, 8 }, new[] { 1, 3, 1, 4, 2, 3, 5, 4 }).Returns(7);
                    yield return new TestCaseData(new[] { 5, 8 }, new[] { 1, 3, 1, 4, 3, 7, 5, 4 }).Returns(-1);
                }
            }
        }

        [TestCaseSource(typeof(Zadanie02Ropucha), nameof(Zadanie02Ropucha.TestCases))]
        public int Zadanie02RopuchaTest(int[] input, int[] A)
        {
           return Zadanie02Ropucha.Solution(input[0], input[1], A);
        }

        class Zadanie03Przyciski
        {
            public static int[] Solution(int b, int n, int[] A)
            {
                var counter = new int[b];
                var currentMax = 0;
                var minimum = 0;

                for (int i = 0; i < n; i++ )
                {
                    var button = A[i];
                    if (button == b + 1)
                    {
                        minimum = currentMax;
                    }
                    else
                    {
                        var newValue = counter[button - 1] = System.Math.Max(minimum, counter[button - 1]) + 1;
                        if (currentMax < newValue)
                        {
                            currentMax = newValue;
                        }
                    }
                }

                for (int y = 0; y < b; y++)
                {
                    counter[y] = System.Math.Max(minimum, counter[y]);
                }

                return counter;
            }
        }

        [Test]
        [TestCase(new[] { 5, 7 }, new[] { 3, 4, 4, 6, 1, 4, 4 }, ExpectedResult = new[] { 3, 2, 2, 4, 2 })]
        // [TestCase(new[] { 5, 8 }, new[] { 1, 3, 1, 4, 3, 7, 5, 4 }, ExpectedResult = -1)]
        public int[] Zadanie03PrzyciskiTest(int[] input, int[] A)
        {
           return Zadanie03Przyciski.Solution(input[0], input[1], A);
        }
    }
}