    using BookStore;

    namespace BookUnitTest
    {
        [TestClass]
        public class BookTest
        {
            public Book book = new Book { Id = 1, Title = "Sample Book", Price = 500};
            public Book bookPriceOutOfRange = new Book { Id = 1, Title = "Another Book", Price = 1500 };
            public Book bookTitleShort = new Book { Id = 1, Title = "B", Price = 250};
            public Book bookTitleNull = new Book { Id = 1, Title = null, Price = 750};


            [TestMethod()]
            public void ToStringMethod()
            {
                string str = book.ToString();
                Assert.AreEqual("1 Sample Book 500", str);
            }

            [TestMethod()]
            public void ValidatePriceTest()
            {
                book.ValidatePrice();
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceOutOfRange.ValidatePrice());
            }

            [TestMethod()]
            public void ValidateTitleTest()
            {
                book.ValidateTitle();
                Assert.ThrowsException<ArgumentException>(() => bookTitleShort.ValidateTitle());
                Assert.ThrowsException<ArgumentException>(() => bookTitleNull.ValidateTitle());
            }

            [TestMethod()]
            public void ValidateTest()
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceOutOfRange.ValidatePrice());
                Assert.ThrowsException<ArgumentException>(() => bookTitleShort.ValidateTitle());
                Assert.ThrowsException<ArgumentException>(() => bookTitleNull.ValidateTitle());
            }

            [DataTestMethod]
            [DataRow(600)]
            [DataRow(1000)]
            [DataRow(1200)]
            public void ValidatePricesTest(int price)
            {
                book.Price = price;
                book.ValidatePrice();
            }

        }
    }
