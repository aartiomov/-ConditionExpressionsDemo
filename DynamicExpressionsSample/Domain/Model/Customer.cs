using System;

namespace ConditionExpressionsDemo.Domain.Model
{
    /// <summary>
    /// Customer model class
    /// </summary>
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int OrdersCount { get; set; }      
        public string Gender { get; set; }  
    }
}