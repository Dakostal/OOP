using NUnit.Framework;
using System;

namespace Tests;

[TestFixture]
public class StudentTests
{
    private string[] CombineArrays(string[] firstNames, string[] lastNames)
    {
        if (firstNames == null || lastNames == null)
            throw new ArgumentNullException("Массивы не могут быть null.");
        if (firstNames.Length != lastNames.Length)
            throw new ArgumentException("Массивы должны быть одинаковой длины.");

        string[] combined = new string[firstNames.Length + lastNames.Length];
        for (int i = 0, j = 0, k = 0; i < combined.Length; i++)
        {
            if (i % 2 == 0)
                combined[i] = firstNames[j++];
            else
                combined[i] = lastNames[k++];
        }
        return combined;
    }

    [Test]
    public void CombineArrays_EvenIndicesAreNames()
    {
        string[] firstNames = { "Алексей", "Борис" };
        string[] lastNames = { "Иванов", "Петров" };
        string[] result = CombineArrays(firstNames, lastNames);
        Assert.AreEqual("Алексей", result[0], "Четный индекс 0 должен содержать имя.");
        Assert.AreEqual("Борис", result[2], "Четный индекс 2 должен содержать имя.");
    }

    [Test]
    public void CombineArrays_OddIndicesAreLastNames()
    {
        string[] firstNames = { "Алексей", "Борис" };
        string[] lastNames = { "Иванов", "Петров" };
        string[] result = CombineArrays(firstNames, lastNames);
        Assert.AreEqual("Иванов", result[1], "Нечетный индекс 1 должен содержать фамилию.");
        Assert.AreEqual("Петров", result[3], "Нечетный индекс 3 должен содержать фамилию.");
    }

    [Test]
    public void CombineArrays_CorrectLength()
    {
        string[] firstNames = { "Алексей", "Борис" };
        string[] lastNames = { "Иванов", "Петров" };
        string[] result = CombineArrays(firstNames, lastNames);
        Assert.AreEqual(4, result.Length, "Длина объединенного массива должна быть 4.");
    }

    [Test]
    public void CombineArrays_EmptyArrays_ReturnsEmpty()
    {
        string[] firstNames = Array.Empty<string>();
        string[] lastNames = Array.Empty<string>();
        string[] result = CombineArrays(firstNames, lastNames);
        Assert.IsEmpty(result, "Объединение пустых массивов должно вернуть пустой массив.");
    }

    [TestCase(new[] { "Алексей" }, new[] { "Иванов" }, ExpectedResult = new[] { "Алексей", "Иванов" })]
    [TestCase(new[] { "Алексей", "Борис" }, new[] { "Иванов", "Петров" }, ExpectedResult = new[] { "Алексей", "Иванов", "Борис", "Петров" })]
    public string[] CombineArrays_MatchesExpected(string[] firstNames, string[] lastNames)
    {
        return CombineArrays(firstNames, lastNames);
    }

    [Test]
    public void CombineArrays_UnequalArrays_ThrowsException()
    {
        string[] firstNames = { "Алексей", "Борис" };
        string[] lastNames = { "Иванов" };
        Assert.Throws<ArgumentException>(() => CombineArrays(firstNames, lastNames), "Разные длины массивов должны вызывать исключение.");
    }

    [Test]
    public void CombineArrays_SingleElementArrays()
    {
        string[] firstNames = { "Алексей" };
        string[] lastNames = { "Иванов" };
        string[] result = CombineArrays(firstNames, lastNames);
        Assert.AreEqual(new[] { "Алексей", "Иванов" }, result);
    }

    [Test]
    public void CombineArrays_NullFirstNames_ThrowsException()
    {
        string[] lastNames = { "Иванов" };
        Assert.Throws<ArgumentNullException>(() => CombineArrays(null!, lastNames));
    }

    [Test]
    public void CombineArrays_NullLastNames_ThrowsException()
    {
        string[] firstNames = { "Алексей" };
        Assert.Throws<ArgumentNullException>(() => CombineArrays(firstNames, null!));
    }

    [Test]
    public void CombineArrays_ThreeElements()
    {
        string[] firstNames = { "Алексей", "Борис", "Виктор" };
        string[] lastNames = { "Иванов", "Петров", "Сидоров" };
        string[] result = CombineArrays(firstNames, lastNames);
        Assert.AreEqual(new[] { "Алексей", "Иванов", "Борис", "Петров", "Виктор", "Сидоров" }, result);
    }

    [Test]
    public void CombineArrays_EmptyFirstNames_ThrowsException()
    {
        string[] firstNames = Array.Empty<string>();
        string[] lastNames = { "Иванов" };
        Assert.Throws<ArgumentException>(() => CombineArrays(firstNames, lastNames), "Разные длины массивов должны вызывать исключение.");
    }
}