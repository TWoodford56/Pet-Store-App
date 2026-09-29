using employeeCodes;
using Xunit;

namespace AE1.Tests
{
    public class EmployeeCodesTests
    {
        [Fact]
        public void Constructor_SetsNameAndPassword()
        {
            EmployeeCodes employeeCodes = new EmployeeCodes("Harry Woodford", "pw12345678");
            Assert.Equal("Harry Woodford", employeeCodes.name);
            Assert.Equal("pw12345678", employeeCodes.password);
        }

        [Fact]
        public void ToString_FormatsNameAndPassword()
        {
            EmployeeCodes employeeCodes = new EmployeeCodes("Harry Woodford", "pw12345678");
            Assert.Equal("Harry Woodford, pw12345678", employeeCodes.ToString());
        }
    }
}
