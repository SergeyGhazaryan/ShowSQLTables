namespace ShowSQLTables
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Date { get; set; }
        public int AuthorId { get; set; }

        public override string ToString()
        {
            return string.Format("{0} \t{1} \t{2} \t{3}", Id, Name, Date, AuthorId);
        }
    }
}
