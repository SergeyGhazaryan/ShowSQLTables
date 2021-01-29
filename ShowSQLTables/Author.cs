namespace ShowSQLTables
{
    class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return string.Format("{0} \t{1} \t{2} \t{3} \t{4}", ID, FirstName, LastName, Age, Country);
        }
    }
}
