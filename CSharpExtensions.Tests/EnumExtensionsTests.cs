using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace EnumUtilities.Tests
{
    [TestFixture]
    public class EnumExtensionsTests
    {
        [Test]
        public void GetFlags_OneValue_ReturnsValue()
        {
            const FlagEnum sampleEnum = FlagEnum.ValueOne;
            var flags = sampleEnum.GetFlags();

            var enumerable = flags as IList<Enum> ?? flags.ToList();
            Assert.That(enumerable.Count(), Is.EqualTo(1));
            Assert.That(enumerable.First(), Is.EqualTo(FlagEnum.ValueOne));
        }

        [Test]
        public void GetFlags_TwoValues_ReturnsBothValues()
        {
            const FlagEnum sampleEnum = FlagEnum.ValueOne | FlagEnum.ValueTwo;
            var flags = sampleEnum.GetFlags();

            var enumerable = flags as Enum[] ?? flags.ToArray();
            Assert.That(enumerable.Count(), Is.EqualTo(2));
            Assert.That(enumerable.Contains(FlagEnum.ValueOne));
            Assert.That(enumerable.Contains(FlagEnum.ValueTwo));
        }

        [Test]
        public void GetFlagsForEnumWithZeroValue_Zero_ReturnsZero()
        {
            const FlagWithZeroEnum sampleEnum = FlagWithZeroEnum.None;
            var flags = sampleEnum.GetFlags();

            var enumerable = flags as IList<Enum> ?? flags.ToList();
            Assert.That(enumerable.Count(), Is.EqualTo(1));
            Assert.That(enumerable.First(), Is.EqualTo(FlagWithZeroEnum.None));
        }

        [Test]
        public void GetFlagsForEnumWithZeroValue_ZeroAndValue_ReturnsBothZeroAndValue()
        {
            const FlagWithZeroEnum sampleEnum = FlagWithZeroEnum.ValueOne;
            var flags = sampleEnum.GetFlags();

            var enumerable = flags as IList<Enum> ?? flags.ToList();
            Assert.That(enumerable.Count(), Is.EqualTo(2));
            Assert.That(enumerable.Contains(FlagWithZeroEnum.None));
            Assert.That(enumerable.Contains(FlagWithZeroEnum.ValueOne));
        }

    }

    [Flags]
    enum FlagEnum
    {
        ValueOne = 1,
        ValueTwo = 2,
        ValueThree = 4,
        ValueFour = 6
    }

    [Flags]
    enum FlagWithZeroEnum
    {
        None = 0,
        ValueOne = 1,
        ValueTwo = 2,
        ValueThree = 4,
        ValueFour = 6
    }
}
