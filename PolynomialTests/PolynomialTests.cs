using NUnit.Framework;
namespace PolynomialTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void PolynomialToString()
        {
            Polynomial.Polynomial myPolinomial = new Polynomial.Polynomial(5,0,3,2,1);
            Assert.AreEqual("5*X^4+3*X^2+2*X^1+1*X^0", myPolinomial.ToString());
        }
    }
}
