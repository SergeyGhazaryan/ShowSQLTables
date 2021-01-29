namespace ShowSQLTables
{
    class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Date { get; set; }
        public int AuthorID { get; set; }

        public override string ToString()
        {
            return string.Format("{0} \t{1} \t{2} \t{3}", ID, Name, Date, AuthorID);
        }
    }
}
