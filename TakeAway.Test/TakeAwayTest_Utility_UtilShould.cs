using System;
using TakeAwayTest.Utility;
using Xunit;

namespace TakeAway.Test
{
    public class TakeAwayTest_Utility_UtilShould
    {
        #region MiniMum Test
        [Fact]
        public void ConvertNumberToMoney_LessThanMinimumAllowedTest()
        {
            var actualRes = Util.ConvertNumberToMoney("-123456789123456789");
            Assert.Null(actualRes);
        } 
        #endregion

        #region MaxMum Test
        [Fact]
        public void ConvertNumberToMoney_LargerThanMaximumAllowedTest()
        {
            var actualRes = Util.ConvertNumberToMoney("123456789123456789");
            Assert.Null(actualRes);
        } 
        #endregion

        #region Zero Test
        [Fact]
        public void ConvertNumberToMoney_ZeroTest()
        {
            var actualRes = Util.ConvertNumberToMoney("0");
            Assert.Equal("ZERO", actualRes);
        } 
        #endregion

        #region Cents Test
        [Fact]
        public void ConvertNumberToMoney_RoundUpTest()
        {
            var actualRes = Util.ConvertNumberToMoney("0.006");
            Assert.Equal("ONE CENTS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_SingleCentsTest()
        {
            var actualRes = Util.ConvertNumberToMoney("0.02");
            Assert.Equal("TWO CENTS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DoubleCentsEndWithZeroTest()
        {
            var actualRes = Util.ConvertNumberToMoney("0.20");
            Assert.Equal("TWENTY CENTS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DoubleCentsTest()
        {
            var actualRes = Util.ConvertNumberToMoney("0.25");
            Assert.Equal("TWENTY - FIVE CENTS", actualRes);
        }
        #endregion

        #region Negative Test
        [Fact]
        public void ConvertNumberToMoney_NegativeTest()
        {
            var actualRes = Util.ConvertNumberToMoney("-10");

            Assert.Equal("NEGATIVE TEN DOLLARS", actualRes);
        }
        #endregion


        #region Hundreds and below test
        [Fact]
        public void ConvertNumberToMoney_DollarsTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("10");
            Assert.Equal("TEN DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("100");
            Assert.Equal("ONE HUNDRED DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsHundredSingleTest()
        {
            var actualRes = Util.ConvertNumberToMoney("101");
            Assert.Equal("ONE HUNDRED AND ONE DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsHundredTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("111");
            Assert.Equal("ONE HUNDRED AND ELEVEN DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsHundredTenCentsTest()
        {
            var actualRes = Util.ConvertNumberToMoney("111.02");
            Assert.Equal("ONE HUNDRED AND ELEVEN DOLLARS AND TWO CENTS", actualRes);
        }
        #endregion

        #region Thousands test
        [Fact]
        public void ConvertNumberToMoney_DollarsThousandTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000");
            Assert.Equal("ONE THOUSAND DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsThousandHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1200");
            Assert.Equal("ONE THOUSAND AND TWO HUNDRED DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsThousandTensTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1012");
            Assert.Equal("ONE THOUSAND AND TWELVE DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsThousandSINGLETest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001");
            Assert.Equal("ONE THOUSAND AND ONE DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsThousandTensSingleTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1221");
            Assert.Equal("ONE THOUSAND AND TWO HUNDRED AND TWENTY - ONE DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsThousandTenSingleCentsTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1221.21");
            Assert.Equal("ONE THOUSAND AND TWO HUNDRED AND TWENTY - ONE DOLLARS AND TWENTY - ONE CENTS", actualRes);
        }
        #endregion

        #region Million test
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000000");
            Assert.Equal("ONE MILLION DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionThousandTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1003000");
            Assert.Equal("ONE MILLION AND THREE THOUSAND DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000300");
            Assert.Equal("ONE MILLION AND THREE HUNDRED DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionTensTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000015");
            Assert.Equal("ONE MILLION AND FIFTEEN DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsMillionThousandHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001500");
            Assert.Equal("ONE MILLION AND ONE THOUSAND AND FIVE HUNDRED DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionThousandTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001050");
            Assert.Equal("ONE MILLION AND ONE THOUSAND AND FIFTY DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionHundredTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000150");
            Assert.Equal("ONE MILLION AND ONE HUNDRED AND FIFTY DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionThousandHundredTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001150");
            Assert.Equal("ONE MILLION AND ONE THOUSAND AND ONE HUNDRED AND FIFTY DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsMillionThousandHundredTenCentsTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001150.55");
            Assert.Equal("ONE MILLION AND ONE THOUSAND AND ONE HUNDRED AND FIFTY DOLLARS AND FIFTY - FIVE CENTS", actualRes);
        }
        #endregion

        #region Billion Test
        [Fact]
        public void ConvertNumberToMoney_DollarsBillionTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000000000");
            Assert.Equal("ONE BILLION DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001000000");
            Assert.Equal("ONE BILLION AND ONE MILLION DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionThousandTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000001000");
            Assert.Equal("ONE BILLION AND ONE THOUSAND DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000000100");
            Assert.Equal("ONE BILLION AND ONE HUNDRED DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionTensTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1000000012");
            Assert.Equal("ONE BILLION AND TWELVE DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionThousandTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001001000");
            Assert.Equal("ONE BILLION AND ONE MILLION AND ONE THOUSAND DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001000100");
            Assert.Equal("ONE BILLION AND ONE MILLION AND ONE HUNDRED DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionTensTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001000010");
            Assert.Equal("ONE BILLION AND ONE MILLION AND TEN DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionThousandHundredTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001001100");
            Assert.Equal("ONE BILLION AND ONE MILLION AND ONE THOUSAND AND ONE HUNDRED DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionThousandTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001001010");
            Assert.Equal("ONE BILLION AND ONE MILLION AND ONE THOUSAND AND TEN DOLLARS", actualRes);
        }

        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionThousandHundredTenTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001001110");
            Assert.Equal("ONE BILLION AND ONE MILLION AND ONE THOUSAND AND ONE HUNDRED AND TEN DOLLARS", actualRes);
        }
        [Fact]
        public void ConvertNumberToMoney_DollarsBillionMillionThousandHundredTenCentsTest()
        {
            var actualRes = Util.ConvertNumberToMoney("1001001110.55");
            Assert.Equal("ONE BILLION AND ONE MILLION AND ONE THOUSAND AND ONE HUNDRED AND TEN DOLLARS AND FIFTY - FIVE CENTS", actualRes);
        }
        #endregion
    }
}
