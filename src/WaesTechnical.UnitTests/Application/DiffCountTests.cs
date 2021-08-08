using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaesTechnical.Domain.Services;
using Xunit;

namespace WaesTechnical.UnitTests.Application
{
    public class DiffCountTests
    {
        private const string BASE64_EXAMPLE_1 = "VGVzdGUgZGlmZmVyZW5jZXM=";
        private const string BASE64_EXAMPLE_2 = "VGVzdGUgZGlGRkVyZW5jQ3M=";

        #region DiffCalculator
        [Fact(DisplayName = "GetDifferences - Must HAVE ONE")]
        public void GetDifferences_Test()
        {
            var ExLeftBytes = Convert.FromBase64String(BASE64_EXAMPLE_1);
            var ExRightBytes = Convert.FromBase64String(BASE64_EXAMPLE_2);

            var _diffCount = new DiffCount();
            var response = _diffCount.GetDifferences(ExLeftBytes, ExRightBytes);
            Assert.Equal(2, response.Count());
        }

        [Fact(DisplayName = "GetDifferences - Must return 3")]
        public void DefineDifference()
        {
            var ExLeftBytes = Convert.FromBase64String(BASE64_EXAMPLE_1);
            var ExRightBytes = Convert.FromBase64String(BASE64_EXAMPLE_2);

            var _diffCount = new DiffCount();
            var dataService = _diffCount.DefineDifference(8, ExLeftBytes, ExRightBytes);
            Assert.Equal(3, dataService.Length);
        }
        #endregion
    }
}
