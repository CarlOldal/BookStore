using System;

namespace BookStore
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return Id + " " + Title + " " + Price;
        }

        public void ValidateId()
        {
            if (Id <= 0)
                throw new ArgumentException("Id must be a positive integer.");
        }

        public void ValidateTitle()
        {
            if (string.IsNullOrEmpty(Title) || Title.Length < 3)
                throw new ArgumentException("Title must not be null and should be at least 3 characters long.");
        }

        public void ValidatePrice()
        {
            if (Price <= 0 || Price > 1200)
                throw new ArgumentOutOfRangeException("Price must be greater than 0 and less than or equal to 1200.");
        }
    }
}
