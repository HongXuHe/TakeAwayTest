using System;
using System.Collections.Generic;
using System.Text;
using TakeAwayTest.Utility;
using Xunit;

namespace TakeAway.Test
{
    public class TakeAwayTest_Utility_StrExtendShould
    {
        #region IsStartWithSpaceTest
        [Fact]
        public void IsStartWithSpaceTrueTest()
        {
            var strStartWithSpace = " 123";
            var bActual = strStartWithSpace.IsStartWithSpace();
            Assert.True(bActual);
        }
        [Fact]
        public void IsStartWithSpaceFalseTest()
        {
            var strStartWithSpace = "123";
            var bActual = strStartWithSpace.IsStartWithSpace();
            Assert.False(bActual);
        } 
        #endregion

        #region IsEndWithSpaceTest
        [Fact]
        public void IsEndWithSpaceTrueTest()
        {
            var strStartWithSpace = "123 ";
            var bActual = strStartWithSpace.IsEndWithSpace();
            Assert.True(bActual);
        }
        [Fact]
        public void IsEndWithSpaceFalseTest()
        {
            var strStartWithSpace = "123";
            var bActual = strStartWithSpace.IsEndWithSpace();
            Assert.False(bActual);
        } 
        #endregion
    }
}
