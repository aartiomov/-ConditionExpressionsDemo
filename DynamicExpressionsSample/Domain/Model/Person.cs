using System;
using System.Collections.Generic;

namespace DynamicExpressionsSample.Domain.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string OrdersCount { get; set; }      
        public string Gender { get; set; }  
    }
}