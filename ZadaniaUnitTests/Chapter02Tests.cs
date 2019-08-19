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
        }

        [Test]
        [TestCase(true, 5, new[] { 1, 4, 3, 2, 5 })]
        [TestCase(false, 5, new[] { 1, 4, 3, 3, 5 })]
        public void Zadanie01PermutacjaTest(bool expected, int n, int[] A)
        {
            Assert.AreEqual(expected, Zadanie01Permutacja.Solution(n, A));
        }
    }
}