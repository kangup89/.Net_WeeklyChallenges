namespace DatabaseAccess.Models
{
    public class Present
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string DisplayName
        {
            get
            {
                return $"{ Name }";
            }
        }
    }
}