﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    using NUnit.Framework.Internal.Execution;

    public class Chapter03Tests
    {
        public static class Tools
        {
            public static int[] CreatePrefixSum(int[] a)
            {
                var result = new int[a.Length + 1];
                int last = 0;
                for (int i = 1; i < result.Length; i++)
                {
                    last = last + a[i - 1];
                    result[i] = last;
                }

                return result;
            }
        }

        [TestCase(new int[] { 2, 3, 8, 1 }, new int[] { 0, 2, 5, 13, 14 })]
        public void CreatePrefixSumTest(int[] input, int[] expected)
        {
            var result = Tools.CreatePrefixSum(input);
            CollectionAssert.AreEquivalent(expected, result);
        }

        class Cwiczenie01Grzybiarz
        {
            public static int SolutionM2(int position, int moves, int[] A)
            {
                var len = A.Length;
                var max = 0;
                for (int maxStepRight = 1; maxStepRight <= moves; maxStepRight++)
                {
                    var direction = 1;
                    var gathered = A[position];
                    var currentPosition = position;
                    var visited = new bool[len];
                    visited[position] = true;

                    for (int step = 1; step <= moves; step++)
                    {
                        if (currentPosition == len - 1 && direction == 1)
                        {
                            direction *= -1;
                        }

                        if (currentPosition == 0 && direction == -1)
                        {
                            direction *= -1;
                        }

                        currentPosition += (1 * direction);
                        if (visited[currentPosition] == false)
                        {
                            gathered += A[currentPosition];
                            visited[currentPosition] = true;
                        }
                    }

                    if (gathered > max)
                    {
                        max = gathered;
                    }
                }

                for (int maxStepLeft = 1; maxStepLeft <= moves; maxStepLeft++)
                {
                    var direction = -1;
                    var gathered = A[position];
                    var currentPosition = position;
                    var visited = new bool[len];
                    visited[position] = true;

                    for (int step = 1; step <= moves; step++)
                    {
                        if (currentPosition == len - 1 && direction == 1)
                        {
                            direction *= -1;
                        }

                        if (currentPosition == 0 && direction == -1)
                        {
                            direction *= -1;
                        }

                        currentPosition += (1 * direction);
                        if (visited[currentPosition] == false)
                        {
                            gathered += A[currentPosition];
                            visited[currentPosition] = true;
                        }
                    }

                    if (gathered > max)
                    {
                        max = gathered;
                    }
                }

                return max;
            }

            public static int SolutionNM(int position, int moves, int[] A)
            {
                var len = A.Length;
                var result = 0;
                var sumyPrefixowe = Tools.CreatePrefixSum(A);
                for (int i = 0; i < System.Math.Min(position, moves); i++)
                {
                    var lewa_poz = position - 1; 
                }

                return result;
            }

            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(4, 6, new List<int>() { 2, 3, 7, 5, 1, 3, 9 }).Returns(25);
                    yield return new TestCaseData(4, 7, new List<int>() { 2, 3, 7, 5, 0, 0, 0 }).Returns(17);
                    yield return new TestCaseData(4, 9, new List<int>() { 2, 3, 7, 5, 0, 0, 0 }).Returns(17);
                }
            }
        }

        [TestCaseSource(typeof(Cwiczenie01Grzybiarz), nameof(Cwiczenie01Grzybiarz.TestCases))]
        public int Cwiczenie01GrzybirarzTestM2(int k, int m, List<int> A)
        {
            return Cwiczenie01Grzybiarz.SolutionM2(k, m, A.ToArray());
        }

        [TestCaseSource(typeof(Cwiczenie01Grzybiarz), nameof(Cwiczenie01Grzybiarz.TestCases))]
        public int Cwiczenie01GrzybirarzTestNM(int k, int m, List<int> A)
        {
            return Cwiczenie01Grzybiarz.SolutionNM(k, m, A.ToArray());
        }

        class Zadanie02Ropucha
        {
            public static int Solution(int target, int n, int[] A)
            {
                var targetSum = (target * (target + 1)) / 2;
                var exists = new bool[target];

                for (int i = 0; i < n; i++)
                {
                    int leaf = A[i];
                    if (leaf > target) continue;
                    if (exists[leaf - 1]) continue;
                    exists[leaf - 1] = true;
                    targetSum -= leaf;
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

                for (int i = 0; i < n; i++)
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