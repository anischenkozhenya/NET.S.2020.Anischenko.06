using NUnit.Framework;
using System;
using Polynomials;

namespace PolynomialTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void PolynomialToString()
        {
            Polynomial polinomialTest0 = new Polynomial(5, 0, 3, 2, 1);
            Polynomial polinomialTest1 = new Polynomial();
            Polynomial polinomialTest2 = new Polynomial(new double[0]);
            Polynomial polinomialTest3 = new Polynomial(new double[] { 5, 0, 3, 2, 1 });
            Polynomial polinomialTest4 = new Polynomial(6);
            Polynomial polinomialTest5 = new Polynomial(5);
            polinomialTest5[0] = 5;
            polinomialTest5[1] = 0;
            polinomialTest5[2] = 3;
            polinomialTest5[3] = 2;
            polinomialTest5[4] = 1;

            Assert.AreEqual("5X^4+3X^2+2X+1", polinomialTest0.ToString());
            Assert.AreEqual("", polinomialTest1.ToString());
            Assert.AreEqual("", polinomialTest2.ToString());
            Assert.AreEqual("5X^4+3X^2+2X+1", polinomialTest3.ToString());
            Assert.AreEqual("", polinomialTest4.ToString());
            Assert.AreEqual("5X^4+3X^2+2X+1", polinomialTest5.ToString());
        }
        [Test]
        public void PolynomialIndexCheck()
        {
            Polynomial polinomialTest0 = new Polynomial(5, 0, 3, 2, 1);
            polinomialTest0[2] = 5;
            Polynomial polinomialTest1 = new Polynomial(5);
            polinomialTest1[2] = 5;

            Assert.AreEqual("5X^4+5X^2+2X+1", polinomialTest0.ToString());
            Assert.AreEqual("5X^2", polinomialTest1.ToString());
        }
        [Test]
        public void PolynomialIndexArgumentOutOfRangeException()
        {
            Polynomial polinomialTest0 = new Polynomial(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => polinomialTest0[3] = 5);
            Assert.Throws<ArgumentOutOfRangeException>(() => polinomialTest0[-1] = 5);
        }
        [Test]
        public void PolynomialSumTwoPolynomials()
        {
            Polynomial myPolinomial1 = new Polynomial(1, 2);
            Polynomial myPolinomial2 = new Polynomial(3, 4, 5);
            Polynomial myPolinomial3 = myPolinomial1 + myPolinomial2;

            Polynomial myPolinomial4 = new Polynomial(-100, 2, 50, 0, 0, 2);
            Polynomial myPolinomial5 = new Polynomial(-10, 3, 4, 0);
            Polynomial myPolinomial6 = myPolinomial4 + myPolinomial5;

            Assert.AreEqual("3X^2+5X+7", myPolinomial3.ToString());
            Assert.AreEqual("-100X^5+2X^4+40X^3+3X^2+4X+2", myPolinomial6.ToString());
        }
        [Test]
        public void PolynomialSumPolynomialAndNumber()
        {            
            Polynomial myPolinomial0 = new Polynomial(3, 4, 5);
            Polynomial myPolinomial1 = myPolinomial0 + 34;
            Polynomial myPolinomial2 = new Polynomial(-100, 2, 50, 0, 0, 2);
            Polynomial myPolinomial3 = 52 + myPolinomial2;

            Assert.AreEqual("3X^2+4X+39", myPolinomial1.ToString());
            Assert.AreEqual("-100X^5+2X^4+50X^3+54", myPolinomial3.ToString());
        }
        [Test]
        public void PolynomialConstructorInitialArgumentOverFlowException()
        {
            Polynomial myPolinomial0;
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial0 = new Polynomial(Double.NaN));
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial0 = new Polynomial(Double.NegativeInfinity));
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial0 = new Polynomial(Double.PositiveInfinity));
        }
        [Test]
        public void PolynomialIndexArgumentOverFlowException()
        {
            Polynomial myPolinomial0 = new Polynomial();
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial0[0] = Double.NegativeInfinity);
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial0[0] = Double.PositiveInfinity);
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial0[0] = Double.NaN);
        }
        [Test]
        public void PolynomialSubtractTwoPolynomials()
        {
            Polynomial myPolinomial1 = new Polynomial(1, 2);
            Polynomial myPolinomial2 = new Polynomial(3, -4, 5);
            Polynomial myPolinomial3 = myPolinomial1 - myPolinomial2;
            Assert.AreEqual("-3X^2+5X-3", myPolinomial3.ToString());
        }
        [Test]
        public void PolynomialSubtractPolynomialAndNumber()
        {
            Polynomial myPolinomial0 = new Polynomial(3, -4, 5);
            Polynomial myPolinomial1 = myPolinomial0 - 15;
            Polynomial myPolinomial2 = new Polynomial(3, -4, 5);
            Polynomial myPolinomial3 = 15 - myPolinomial2;
            Assert.AreEqual("3X^2-4X-10", myPolinomial1.ToString());
            Assert.AreEqual("-3X^2+4X+10", myPolinomial3.ToString());
        }
        [Test]
        public void PolynomialMultiplicationNumberByPolynomial()
        {
            Polynomial myPolinomial1 = new Polynomial(1, 2, -3, 4);
            Polynomial myPolinomial2 = new Polynomial(-1, -2, 8);
            Polynomial myPolinomial3 = 2 * myPolinomial1;
            Polynomial myPolinomial4 = -2 * myPolinomial2;
            Assert.AreEqual("2X^3+4X^2-6X+8", myPolinomial3.ToString());
            Assert.AreEqual("2X^2+4X-16", myPolinomial4.ToString());
        }
        [Test]
        public void PolynomialMultiplicationPolynomialByNumber()
        {
            Polynomial myPolinomial1 = new Polynomial(1, 2, -3, 4);
            Polynomial myPolinomial2 = new Polynomial(-1, -2, 8);
            Polynomial myPolinomial3 = myPolinomial1 * 2;
            Polynomial myPolinomial4 = myPolinomial2 * -2;
            Assert.AreEqual("2X^3+4X^2-6X+8", myPolinomial3.ToString());
            Assert.AreEqual("2X^2+4X-16", myPolinomial4.ToString());
        }
        [Test]
        public void PolynomialMultiplicationTwoPolynomials()
        {
            Polynomial myPolinomial1 = new Polynomial(1, 2, 3);
            Polynomial myPolinomial2 = new Polynomial(3, 5);
            Polynomial myPolinomial3 = myPolinomial2 * myPolinomial1;
            Assert.AreEqual("3X^3+11X^2+19X+15", myPolinomial3.ToString());
        }
        [Test]
        public void PolynomialDivisionPolynomialByNumber()
        {
            Polynomial myPolinomial0 = new Polynomial(1, 2, 8);
            Polynomial myPolinomial1 = myPolinomial0 / 4;
            Assert.AreEqual("0,25X^2+0,5X+2", myPolinomial1.ToString());
        }
        [Test]
        public void PolynomialEquality()
        {
            Polynomial myPolinomial0 = new Polynomial(1, 2, 8);
            Polynomial myPolinomial1 = new Polynomial(1, 2, 8);
            Polynomial myPolinomial2 = new Polynomial(1, 3, 8);
            Polynomial myPolinomial3 = new Polynomial(1, 2, 8, 5);
            Assert.IsTrue(myPolinomial0.Equals(myPolinomial1));
            Assert.IsTrue(myPolinomial0 == myPolinomial1);
            Assert.IsFalse(myPolinomial0 == myPolinomial2);
            Assert.IsFalse(myPolinomial0 == myPolinomial3);
        }
        [Test]
        public void PolynomialNotEquality()
        {
            Polynomial myPolinomial0 = new Polynomial(1, 2, 8);
            Polynomial myPolinomial1 = new Polynomial(1, 2, 8);
            Polynomial myPolinomial2 = new Polynomial(1, 3, 8);
            Polynomial myPolinomial3 = new Polynomial(1, 2, 8, 5);
            Assert.IsFalse(myPolinomial0 != myPolinomial1);
            Assert.IsTrue(myPolinomial0 != myPolinomial2);
            Assert.IsTrue(myPolinomial0 != myPolinomial3);
        }
    }
}

