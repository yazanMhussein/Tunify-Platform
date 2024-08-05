namespace TunifyPlatform.Models
{
    public class User
    {
        public int UserID { get; set; }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime Join_Date { get; set; }


        // ForeignKey ID AND Class
        public int SubscripitionID { get; set; }
        public Subscripition Subscripition { get; set; } 
        
        
    }
}
