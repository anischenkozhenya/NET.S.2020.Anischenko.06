using NUnit.Framework;
using System;

namespace PolynomialTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void PolynomialToString()
        {
            Polynomial.Polynomial polinomialTest0 = new Polynomial.Polynomial(5, 0, 3, 2, 1);
            Polynomial.Polynomial polinomialTest1 = new Polynomial.Polynomial();
            Polynomial.Polynomial polinomialTest2 = new Polynomial.Polynomial(new double[0]);
            Polynomial.Polynomial polinomialTest3 = new Polynomial.Polynomial(new double[] { 5, 0, 3, 2, 1 });
            Polynomial.Polynomial polinomialTest4 = new Polynomial.Polynomial(6);
            Polynomial.Polynomial polinomialTest5 = new Polynomial.Polynomial(5);
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
            Polynomial.Polynomial polinomialTest0 = new Polynomial.Polynomial(5, 0, 3, 2, 1);
            polinomialTest0[2] = 5;
            Polynomial.Polynomial polinomialTest1 = new Polynomial.Polynomial(5);
            polinomialTest1[2] = 5;

            Assert.AreEqual("5X^4+5X^2+2X+1", polinomialTest0.ToString());
            Assert.AreEqual("5X^2", polinomialTest1.ToString());
        }
        [Test]
        public void PolynomialIndexArgumentOutOfRangeException()
        {
            Polynomial.Polynomial polinomialTest0 = new Polynomial.Polynomial(3);

            Assert.Throws<ArgumentOutOfRangeException>(() => polinomialTest0[3] = 5);
            Assert.Throws<ArgumentOutOfRangeException>(() => polinomialTest0[-1] = 5);
        }
        [Test]
        public void PolynomialSumTwo()
        {
            Polynomial.Polynomial myPolinomial1 = new Polynomial.Polynomial(1, 2);
            Polynomial.Polynomial myPolinomial2 = new Polynomial.Polynomial(3, 4, 5);
            Polynomial.Polynomial myPolinomial3 = myPolinomial1 + myPolinomial2;

            Polynomial.Polynomial myPolinomial4 = new Polynomial.Polynomial(-100, 2, 50, 0, 0, 2);
            Polynomial.Polynomial myPolinomial5 = new Polynomial.Polynomial(-10, 3, 4, 0);
            Polynomial.Polynomial myPolinomial6 = myPolinomial4 + myPolinomial5;

            Assert.AreEqual("3X^2+5X+7", myPolinomial3.ToString());
            Assert.AreEqual("-100X^5+2X^4+40X^3+3X^2+4X+2", myPolinomial6.ToString());
        }

        [Test]
        public void PolynomialSumTwoOverFlowException()
        {
            Polynomial.Polynomial myPolinomial1 = new Polynomial.Polynomial(Double.MaxValue, 2);
            Polynomial.Polynomial myPolinomial2 = new Polynomial.Polynomial(3, Double.MaxValue, 5);
            Polynomial.Polynomial myPolinomial3;

            Polynomial.Polynomial myPolinomial4 = new Polynomial.Polynomial(-100, 2, Double.MinValue, 0, 0, 2);
            Polynomial.Polynomial myPolinomial5 = new Polynomial.Polynomial(-1, 3, 4, 0);
            Polynomial.Polynomial myPolinomial6;

            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial3 = myPolinomial1 + myPolinomial2);
            Assert.Throws<ArgumentOutOfRangeException>(() => myPolinomial6 = myPolinomial4 + myPolinomial5);
        }
        [Test]
        public void PolynomialDivTwo()
        {
            Polynomial.Polynomial myPolinomial1 = new Polynomial.Polynomial(1, 2);
            Polynomial.Polynomial myPolinomial2 = new Polynomial.Polynomial(3, -4, 5);
            Polynomial.Polynomial myPolinomial3 = myPolinomial1 - myPolinomial2;
            Assert.AreEqual("-3X^2+5X-3", myPolinomial3.ToString());
        }
            [Test]
        public void Polynomial345345()
        {
            Polynomial.Polynomial myPolinomial1 = new Polynomial.Polynomial(1, 2, -3, 4);
            Polynomial.Polynomial myPolinomial2 = new Polynomial.Polynomial(-1, -2, 8);
            Polynomial.Polynomial myPolinomial3 = 2 * myPolinomial1;
            Polynomial.Polynomial myPolinomial4 = -2 * myPolinomial2;
            Assert.AreEqual("2X^3+4X^2-6X+8", myPolinomial3.ToString());
            Assert.AreEqual("2X^2+4X-16", myPolinomial4.ToString());
        }
        [Test]
        public void Polynomialdfdfdf()
        {
            Polynomial.Polynomial myPolinomial1 = new Polynomial.Polynomial(1, 2, -3, 4);
            Polynomial.Polynomial myPolinomial2 = new Polynomial.Polynomial(-1, -2, 8);
            Polynomial.Polynomial myPolinomial3 = myPolinomial1*2  ;
            Polynomial.Polynomial myPolinomial4 =  myPolinomial2* -2;
            Assert.AreEqual("2X^3+4X^2-6X+8", myPolinomial3.ToString());
            Assert.AreEqual("2X^2+4X-16", myPolinomial4.ToString());
        }
        [Test]
        public void Polynomial435345()
        {
            Polynomial.Polynomial myPolinomial1 = new Polynomial.Polynomial(1, 2, 3);
            Polynomial.Polynomial myPolinomial2 = new Polynomial.Polynomial(3, 5);
            Polynomial.Polynomial myPolinomial3 = myPolinomial2 * myPolinomial1;
            Assert.AreEqual("3X^3+11X^2+19X+15", myPolinomial3.ToString());
        }
    }
}

