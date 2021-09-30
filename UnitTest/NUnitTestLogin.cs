using NUnit.Framework;
using BookAPI.Models.UserModels;
using BookAPI.Models;
using System;
namespace BookAPI.UnitTest
{
    [TestFixture]
    public class NUnitTestLogin
    {
        private static string conString = "Data Source=DEATH;Initial Catalog=BOOK_MUA;Persist Security Info=True;User ID=sa;Password=123456";
        private UserManagement um;

        [SetUp]
        public void SetUp()
        {
            um = new UserManagement(conString);
        }

        private User[] expectedListCorrect = new User[] {
            new User()
            {
                UserID = "JOJO",
                Password = "123",
                FullName = "Joseph Joestar",
                Email = "nigerundayo@jj.ba",
                Phone = "9876543210",
                Address = "England",
                RoleID = "US"
            },
            new User()
            {
                UserID = "POLMAO",
                Password = "123333",
                FullName = "Omaru Polmao",
                Email = "oma@ru.polmao",
                Phone = "1232134552",
                Address = "NANI",
                RoleID = "AD"
            }
        };

        //Correct username, password
        [Test]
        public void TestLoginWithCorrectAccount()
        {
            foreach (var expected in expectedListCorrect)
            {
                if (expected!= null)
                Assert.AreEqual(true, expected.Equals(um.Login(expected.UserID, expected.Password)));
            }
        }
        private User[] expectedListInCorrect = new User[] {
            new User()
            {
                UserID = "asdasdas4dsada",
                Password = "asdsadasdsadsadsad"
            },
            new User()
            {
                UserID = "s87d8w787e8w1d",
                Password = "8789wqe78w9e79ewq"
            },
            new User()
            {
                UserID = "JOJO",
                Password = "8789wqe78w9e79ewq"
            }
        };

        //Wrong username or password
        [Test]
        public void TestLoginWithIncorrectAccount()
        {
            foreach (var wrongExpect in expectedListInCorrect)
            {
                Assert.Throws<NullReferenceException>(
                    () => {
                            um.Login(wrongExpect.UserID, wrongExpect.Password).ToString();
                    });
            }
        }

        // Invalid username, password
        [Test]
        public void TestLoginWithIncorrectCharacterRangeInput()
        {
            Assert.Throws<ArgumentException> (
              () => {
                  um.Login("ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA ORA", "123456");
                  um.Login("654321", "MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA MUDA");
                  um.Login("", "");
                  um.Login(null, null);
              }
            );
        }
    }
}
