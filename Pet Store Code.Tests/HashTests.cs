using hash;
using Xunit;

namespace AE1.Tests
{
    public class HashTests
    {
        [Fact]
        public void HashPassword_ProducesAnEncodedHash()
        {
            string pass = "abcd";
            string hashed = Hash.HashPassword(pass);
            Assert.DoesNotMatch(pass, hashed);
        }

        [Fact]
        public void HashPassword_SamePasswordProducesDifferentHashesEachTime()
        {
            // TODO: hash the same password twice and compare the two hashes
            string hashed = Hash.HashPassword("psw1234567");
            string hashed2 = Hash.HashPassword(hashed);
            Assert.DoesNotMatch(hashed, hashed2);
        }

        [Fact]
        public void VerifyPassword_CorrectPasswordReturnsTrue()
        {
            string hashed = Hash.HashPassword("psw1234567");
            Assert.True(Hash.VerifyPassword(hashed, "psw1234567"));
        }

        [Fact]
        public void VerifyPassword_WrongPasswordReturnsFalse()
        {
            string hashed = Hash.HashPassword("psw1234567");
            Assert.False(Hash.VerifyPassword(hashed, "nopass"));
        }
    }
}
