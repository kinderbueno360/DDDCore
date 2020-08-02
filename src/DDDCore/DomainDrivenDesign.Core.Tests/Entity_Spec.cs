namespace DomainDrivenDesign.Core.Tests
{
    using DomainDrivenDesign.Core.Tests.Base.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class Entity_Spec
    {
        [Fact]
        public void Payment_compare_with_Payment_with_same_id_should_be_valid()
        {
            // Arrange
            var paymentDate = DateTime.Now;
            Payment payment = new Payment("PM-001", "123", "323", paymentDate, 10m, "KinderBueno");
            Payment payment2 = new Payment("PM-001", "123", "323", paymentDate, 10m, "KinderBueno");

            // Action
            var resulComparison = payment.Equals(payment2);

            // Assert
            Assert.True(resulComparison);
        }
    }
}
