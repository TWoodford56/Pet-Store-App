using System.Linq;
using employeeCodes;
using hash;
using workers;
using Xunit;

namespace AE1.Tests
{
    public class WorkersTests
    {
        [Fact]
        public void AddEmployee_NewNameAndPassword_IsAddedAndHashed()
        {
            var workers = new Workers();

            workers.addEmployee("psw1234567", "Harry Woodford");

            var stored = workers.passwords.Single(p => p.name == "Harry Woodford");
            Assert.NotEqual("psw1234567", stored.password);
            Assert.True(Hash.VerifyPassword(stored.password, "psw1234567"));
        }

        [Fact]
        public void AddEmployee_DuplicateName_IsRejected()
        {
            var workers = new Workers();

            workers.addEmployee("psw1234567", "Tom Woodford");
            workers.addEmployee("differentPassword1", "Tom Woodford");

            var stored = Assert.Single(workers.passwords);
            Assert.True(Hash.VerifyPassword(stored.password, "psw1234567"));
        }

        [Fact]
        public void AddEmployee_DuplicatePassword_IsRejected()
        {
            var workers = new Workers();

            workers.addEmployee("psw1234567", "Tom Woodford");
            workers.addEmployee("psw1234567", "Harry Woodford");

            var stored = Assert.Single(workers.passwords);
            Assert.Equal("Tom Woodford", stored.name);
        }

        [Fact]
        public void RemoveEmployee_CorrectNameAndPassword_IsRemoved()
        {
            var workers = new Workers();
            workers.addEmployee("psw1234567", "Tom Woodford");

            workers.removeEmployee("psw1234567", "Tom Woodford");

            Assert.Empty(workers.passwords);
        }

        [Fact]
        public void RemoveEmployee_WrongPassword_IsNotRemoved()
        {
            var workers = new Workers();
            workers.addEmployee("psw1234567", "Tom Woodford");

            workers.removeEmployee("wrongPassword1", "Tom Woodford");

            Assert.Single(workers.passwords);
        }

        [Fact]
        public void WriteToCSVThenOpenCSV_RoundTripsEmployees()
        {
            var original = new Workers();
            original.addEmployee("psw1234567", "Tom Woodford");

            string filePath = Path.GetTempFileName();
            try
            {
                original.writeToCSV(filePath);

                var reloaded = new Workers();
                reloaded.openCSV(filePath);

                var stored = reloaded.passwords.Single(p => p.name == "Tom Woodford");
                Assert.True(Hash.VerifyPassword(stored.password, "psw1234567"));
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
