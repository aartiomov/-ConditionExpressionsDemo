using ConditionExpressionsDemo.Common;
using ConditionExpressionsDemo.Domain.Model;
using System;

namespace ConditionExpressionsDemo.Converters
{
    public static class CustomerConverter
    {
        public static IEvaluationContext ToEvaluationContext(this Customer customer)
        {
            var now = DateTime.Now;
            var bday = customer.BirthDate == null ? now : customer.BirthDate.Value;

            int age = now.Year - bday.Year;
            if (now < bday.AddYears(age)) age--;

            return new EvaluationContext { CustomerGender = customer.Gender, FirstName = customer.FirstName, LastName = customer.LastName, OrdersCount = customer.OrdersCount, CustomerAge = age };
        }
    }
}