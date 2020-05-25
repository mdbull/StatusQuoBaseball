using System;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Fraction.
    /// </summary>
    public class Fraction
    {
        /// <summary>
        /// Class attributes/members
        /// </summary>
        long m_iNumerator;
        long m_iDenominator;

        /// <summary>
        /// Constructors
        /// </summary>
        public Fraction()
        {
            Initialize(0, 1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> class.
        /// </summary>
        /// <param name="iWholeNumber">I whole number.</param>
        public Fraction(long iWholeNumber)
        {
            Initialize(iWholeNumber, 1);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> class.
        /// </summary>
        /// <param name="dDecimalValue">D decimal value.</param>
        public Fraction(double dDecimalValue)
        {
            Fraction temp = ToFraction(dDecimalValue);
            Initialize(temp.Numerator, temp.Denominator);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> class.
        /// </summary>
        /// <param name="strValue">String value.</param>
        public Fraction(string strValue)
        {
            Fraction temp = ToFraction(strValue);
            Initialize(temp.Numerator, temp.Denominator);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> class.
        /// </summary>
        /// <param name="iNumerator">I numerator.</param>
        /// <param name="iDenominator">I denominator.</param>
        public Fraction(long iNumerator, long iDenominator)
        {
            Initialize(iNumerator, iDenominator);
        }

        /// <summary>
        /// Internal function for constructors
        /// </summary>
        private void Initialize(long iNumerator, long iDenominator)
        {
            Numerator = iNumerator;
            Denominator = iDenominator;
            ReduceFraction(this);
        }

        /// <summary>
        /// Properites
        /// </summary>
        public long Denominator
        {
            get
            { return m_iDenominator; }
            set
            {
                if (value != 0)
                    m_iDenominator = value;
                else
                    throw new FractionException("Denominator cannot be assigned a ZERO Value");
            }
        }


        /// <summary>
        /// Gets or sets the numerator.
        /// </summary>
        /// <value>long</value>
        public long Numerator
        {
            get
            { return m_iNumerator; }
            set
            { m_iNumerator = value; }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <value>long</value>
        public long Value
        {
            set
            {
                m_iNumerator = value;
                m_iDenominator = 1;
            }
        }

        /// <summary>
        /// The function returns the current Fraction object as double
        /// </summary>
        public double ToDouble()
        {
            return ((double)this.Numerator / this.Denominator);
        }

        /// <summary>
        /// The function returns the current Fraction object as a string
        /// </summary>
        public override string ToString()
        {
            string str;
            if (this.Denominator == 1)
                str = this.Numerator.ToString();
            else
                str = this.Numerator + "/" + this.Denominator;
            return str;
        }
        /// <summary>
        /// The function takes an string as an argument and returns its corresponding reduced fraction
        /// the string can be an in the form of and integer, double or fraction.
        /// e.g it can be like "123" or "123.321" or "123/456"
        /// </summary>
        public static Fraction ToFraction(string strValue)
        {
            int i;
            for (i = 0; i < strValue.Length; i++)
                if (strValue[i] == '/')
                    break;

            if (i == strValue.Length)       // if string is not in the form of a fraction
                                            // then it is double or integer
                return (Convert.ToDouble(strValue));
            //return ( ToFraction( Convert.ToDouble(strValue) ) );

            // else string is in the form of Numerator/Denominator
            long iNumerator = Convert.ToInt64(strValue.Substring(0, i));
            long iDenominator = Convert.ToInt64(strValue.Substring(i + 1));
            return new Fraction(iNumerator, iDenominator);
        }


        /// <summary>
        /// The function takes a floating point number as an argument 
        /// and returns its corresponding reduced fraction
        /// </summary>
        public static Fraction ToFraction(double dValue)
        {
            try
            {
                checked
                {
                    Fraction frac;
                    double EPSILON = Double.Epsilon;
                    if (Math.Abs(dValue % 1) < EPSILON) // if whole number
                    {
                        frac = new Fraction((long)dValue);
                    }
                    else
                    {
                        double dTemp = dValue;
                        long iMultiple = 1;
                        string strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E", StringComparison.CurrentCulture) > 0)   // if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }
                        int i = 0;
                        while (strTemp[i] != '.')
                            i++;
                        int iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0)
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }
                        frac = new Fraction((int)Math.Round(dTemp), iMultiple);
                    }
                    return frac;
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Conversion not possible due to overflow");
            }
            catch (Exception)
            {
                throw new FractionException("Conversion not possible");
            }
        }

        /// <summary>
        /// The function replicates current Fraction object
        /// </summary>
        public Fraction Duplicate()
        {
            Fraction frac = new Fraction();
            frac.Numerator = Numerator;
            frac.Denominator = Denominator;
            return frac;
        }

        /// <summary>
        /// The function returns the inverse of a Fraction object
        /// </summary>
        public static Fraction Inverse(Fraction frac1)
        {
            if (frac1.Numerator == 0)
                throw new FractionException("Operation not possible (Denominator cannot be assigned a ZERO Value)");

            long iNumerator = frac1.Denominator;
            long iDenominator = frac1.Numerator;
            return (new Fraction(iNumerator, iDenominator));
        }


        /// <summary>
        /// Operators for the Fraction object
        /// includes -(unary), and binary opertors such as +,-,*,/		
        /// </summary>
        public static Fraction operator -(Fraction frac1)
        { return (Negate(frac1)); }

        /// <summary>
        /// Adds a <see cref="StatusQuoBaseball.Utilities.Fraction"/> to a
        /// <see cref="StatusQuoBaseball.Utilities.Fraction"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to add.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to add.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the sum of the values of <c>frac1</c> and <c>frac2</c>.</returns>
        public static Fraction operator +(Fraction frac1, Fraction frac2)
        { return (Add(frac1, frac2)); }

        /// <summary>
        /// Adds a <see cref="int"/> to a <see cref="StatusQuoBaseball.Utilities.Fraction"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="iNo">The first <see cref="int"/> to add.</param>
        /// <param name="frac1">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to add.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the sum of the values of <c>iNo</c> and <c>frac1</c>.</returns>
        public static Fraction operator +(int iNo, Fraction frac1)
        { return (Add(frac1, new Fraction(iNo))); }

        /// <summary>
        /// Adds a <see cref="StatusQuoBaseball.Utilities.Fraction"/> to a <see cref="int"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to add.</param>
        /// <param name="iNo">The second <see cref="int"/> to add.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the sum of the values of <c>frac1</c> and <c>iNo</c>.</returns>
        public static Fraction operator +(Fraction frac1, int iNo)
        { return (Add(frac1, new Fraction(iNo))); }

        /// <summary>
        /// Adds a <see cref="double"/> to a <see cref="StatusQuoBaseball.Utilities.Fraction"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="dbl">The first <see cref="double"/> to add.</param>
        /// <param name="frac1">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to add.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the sum of the values of <c>dbl</c> and <c>frac1</c>.</returns>
		public static Fraction operator +(double dbl, Fraction frac1)
        { return (Add(frac1, Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Adds a <see cref="StatusQuoBaseball.Utilities.Fraction"/> to a <see cref="double"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to add.</param>
        /// <param name="dbl">The second <see cref="double"/> to add.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the sum of the values of <c>frac1</c> and <c>dbl</c>.</returns>
        public static Fraction operator +(Fraction frac1, double dbl)
        { return (Add(frac1, Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Subtracts a <see cref="StatusQuoBaseball.Utilities.Fraction"/> from a
        /// <see cref="StatusQuoBaseball.Utilities.Fraction"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to subtract from (the minuend).</param>
        /// <param name="frac2">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> minus <c>frac2</c>.</returns>
        public static Fraction operator -(Fraction frac1, Fraction frac2)
        { return (Add(frac1, -frac2)); }

        /// <summary>
        /// Subtracts a <see cref="int"/> from a <see cref="StatusQuoBaseball.Utilities.Fraction"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="iNo">The <see cref="int"/> to subtract from (the minuend).</param>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>iNo</c> minus <c>frac1</c>.</returns>
        public static Fraction operator -(int iNo, Fraction frac1)
        { return (Add(-frac1, new Fraction(iNo))); }

        /// <summary>
        /// Subtracts a <see cref="StatusQuoBaseball.Utilities.Fraction"/> from a <see cref="int"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to subtract from (the minuend).</param>
        /// <param name="iNo">The <see cref="int"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> minus <c>iNo</c>.</returns>
        public static Fraction operator -(Fraction frac1, int iNo)
        { return (Add(frac1, -(new Fraction(iNo)))); }

        /// <summary>
        /// Subtracts a <see cref="double"/> from a <see cref="StatusQuoBaseball.Utilities.Fraction"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="dbl">The <see cref="double"/> to subtract from (the minuend).</param>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>dbl</c> minus <c>frac1</c>.</returns>
		public static Fraction operator -(double dbl, Fraction frac1)
        { return (Add(-frac1, Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Subtracts a <see cref="StatusQuoBaseball.Utilities.Fraction"/> from a <see cref="double"/>, yielding a new <see cref="T:StatusProBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to subtract from (the minuend).</param>
        /// <param name="dbl">The <see cref="double"/> to subtract (the subtrahend).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> minus <c>dbl</c>.</returns>
        public static Fraction operator -(Fraction frac1, double dbl)
        { return (Add(frac1, -Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Computes the product of <c>frac1</c> and <c>frac2</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to multiply.</param>
        /// <param name="frac2">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to multiply.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> * <c>frac2</c>.</returns>
        public static Fraction operator *(Fraction frac1, Fraction frac2)
        { return (Multiply(frac1, frac2)); }

        /// <summary>
        /// Computes the product of <c>iNo</c> and <c>frac1</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="iNo">The <see cref="int"/> to multiply.</param>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to multiply.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>iNo</c> * <c>frac1</c>.</returns>
        public static Fraction operator *(int iNo, Fraction frac1)
        { return (Multiply(frac1, new Fraction(iNo))); }

        /// <summary>
        /// Computes the product of <c>frac1</c> and <c>iNo</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to multiply.</param>
        /// <param name="iNo">The <see cref="int"/> to multiply.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> * <c>iNo</c>.</returns>
        public static Fraction operator *(Fraction frac1, int iNo)
        { return (Multiply(frac1, new Fraction(iNo))); }

        /// <summary>
        /// Computes the product of <c>dbl</c> and <c>frac1</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="dbl">The <see cref="double"/> to multiply.</param>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to multiply.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>dbl</c> * <c>frac1</c>.</returns>
        public static Fraction operator *(double dbl, Fraction frac1)
        { return (Multiply(frac1, Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Computes the product of <c>frac1</c> and <c>dbl</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to multiply.</param>
        /// <param name="dbl">The <see cref="double"/> to multiply.</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> * <c>dbl</c>.</returns>
        public static Fraction operator *(Fraction frac1, double dbl)
        { return (Multiply(frac1, Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Computes the division of <c>frac1</c> and <c>frac2</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to divide (the divident).</param>
        /// <param name="frac2">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to divide (the divisor).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> / <c>frac2</c>.</returns>
        public static Fraction operator /(Fraction frac1, Fraction frac2)
        { return (Multiply(frac1, Inverse(frac2))); }

        /// <summary>
        /// Computes the division of <c>iNo</c> and <c>frac1</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="iNo">The <see cref="int"/> to divide (the divident).</param>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to divide (the divisor).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>iNo</c> / <c>frac1</c>.</returns>
        public static Fraction operator /(int iNo, Fraction frac1)
        { return (Multiply(Inverse(frac1), new Fraction(iNo))); }

        /// <summary>
        /// Computes the division of <c>frac1</c> and <c>iNo</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to divide (the divident).</param>
        /// <param name="iNo">The <see cref="int"/> to divide (the divisor).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> / <c>iNo</c>.</returns>
        public static Fraction operator /(Fraction frac1, int iNo)
        { return (Multiply(frac1, Inverse(new Fraction(iNo)))); }

        /// <summary>
        /// Computes the division of <c>dbl</c> and <c>frac1</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="dbl">The <see cref="double"/> to divide (the divident).</param>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to divide (the divisor).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>dbl</c> / <c>frac1</c>.</returns>
        public static Fraction operator /(double dbl, Fraction frac1)
        { return (Multiply(Inverse(frac1), Fraction.ToFraction(dbl))); }

        /// <summary>
        /// Computes the division of <c>frac1</c> and <c>dbl</c>, yielding a new <see cref="T:StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The <see cref="StatusQuoBaseball.Utilities.Fraction"/> to divide (the divident).</param>
        /// <param name="dbl">The <see cref="double"/> to divide (the divisor).</param>
        /// <returns>The <see cref="T:StatusQuoBaseball.Utilities.Fraction"/> that is the <c>frac1</c> / <c>dbl</c>.</returns>
        public static Fraction operator /(Fraction frac1, double dbl)
        { return (Multiply(frac1, Fraction.Inverse(Fraction.ToFraction(dbl)))); }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StatusQuoBaseball.Utilities.Fraction"/> is equal to
        /// another specified <see cref="StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> and <c>frac2</c> are equal; otherwise, <c>false</c>.</returns>
		public static bool operator ==(Fraction frac1, Fraction frac2)
        { return frac1.Equals(frac2); }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StatusQuoBaseball.Utilities.Fraction"/> is not equal
        /// to another specified <see cref="StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> and <c>frac2</c> are not equal; otherwise, <c>false</c>.</returns>
		public static bool operator !=(Fraction frac1, Fraction frac2)
        { return (!frac1.Equals(frac2)); }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StatusQuoBaseball.Utilities.Fraction"/> is equal to
        /// another specified <see cref="int"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="iNo">The second <see cref="int"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> and <c>iNo</c> are equal; otherwise, <c>false</c>.</returns>
		public static bool operator ==(Fraction frac1, int iNo)
        { return frac1.Equals(new Fraction(iNo)); }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StatusQuoBaseball.Utilities.Fraction"/> is not equal
        /// to another specified <see cref="int"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="iNo">The second <see cref="int"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> and <c>iNo</c> are not equal; otherwise, <c>false</c>.</returns>
		public static bool operator !=(Fraction frac1, int iNo)
        { return (!frac1.Equals(new Fraction(iNo))); }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StatusQuoBaseball.Utilities.Fraction"/> is equal to
        /// another specified <see cref="double"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="dbl">The second <see cref="double"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> and <c>dbl</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Fraction frac1, double dbl)
        { return frac1.Equals(new Fraction(dbl)); }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StatusQuoBaseball.Utilities.Fraction"/> is not equal
        /// to another specified <see cref="double"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="dbl">The second <see cref="double"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> and <c>dbl</c> are not equal; otherwise, <c>false</c>.</returns>
		public static bool operator !=(Fraction frac1, double dbl)
        { return (!frac1.Equals(new Fraction(dbl))); }

        /// <summary>
        /// Determines whether one specified <see cref="StatusQuoBaseball.Utilities.Fraction"/> is lower than another
        /// specfied <see cref="StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> is lower than <c>frac2</c>; otherwise, <c>false</c>.</returns>
        public static bool operator <(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator < frac2.Numerator * frac1.Denominator; }

        /// <summary>
        /// Determines whether one specified <see cref="StatusQuoBaseball.Utilities.Fraction"/> is greater than another
        /// specfied <see cref="StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> is greater than <c>frac2</c>; otherwise, <c>false</c>.</returns>
		public static bool operator >(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator > frac2.Numerator * frac1.Denominator; }

        /// <summary>
        /// Determines whether one specified <see cref="StatusQuoBaseball.Utilities.Fraction"/> is lower than or equal
        /// to another specfied <see cref="StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> is lower than or equal to <c>frac2</c>; otherwise, <c>false</c>.</returns>
		public static bool operator <=(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator <= frac2.Numerator * frac1.Denominator; }

        /// <summary>
        /// Determines whether one specified <see cref="StatusQuoBaseball.Utilities.Fraction"/> is greater than or equal
        /// to another specfied <see cref="StatusQuoBaseball.Utilities.Fraction"/>.
        /// </summary>
        /// <param name="frac1">The first <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <param name="frac2">The second <see cref="StatusQuoBaseball.Utilities.Fraction"/> to compare.</param>
        /// <returns><c>true</c> if <c>frac1</c> is greater than or equal to <c>frac2</c>; otherwise, <c>false</c>.</returns>
        public static bool operator >=(Fraction frac1, Fraction frac2)
        { return frac1.Numerator * frac2.Denominator >= frac2.Numerator * frac1.Denominator; }


        /// <summary>
        /// overloaed user defined conversions: from numeric data types to Fractions
        /// </summary>
        public static implicit operator Fraction(long lNo)
        { return new Fraction(lNo); }

        /// <summary>
        /// Ops the implicit.
        /// </summary>
        /// <returns>The implicit.</returns>
        /// <param name="dNo">D no.</param>
		public static implicit operator Fraction(double dNo)
        { return new Fraction(dNo); }

        /// <summary>
        /// Ops the implicit.
        /// </summary>
        /// <returns>The implicit.</returns>
        /// <param name="strNo">String no.</param>
		public static implicit operator Fraction(string strNo)
        { return new Fraction(strNo); }

        /// <summary>
        /// overloaed user defined conversions: from fractions to double and string
        /// </summary>
        public static explicit operator double(Fraction frac)
        { return frac.ToDouble(); }

        /// <summary>
        /// Ops the implicit.
        /// </summary>
        /// <returns>The implicit.</returns>
        /// <param name="frac">Frac.</param>
		public static implicit operator string(Fraction frac)
        { return frac.ToString(); }

        /// <summary>
        /// checks whether two fractions are equal
        /// </summary>
        public override bool Equals(object obj)
        {
            Fraction frac = (Fraction)obj;
            return (Numerator == frac.Numerator && Denominator == frac.Denominator);
        }

        /// <summary>
        /// returns a hash code for this fraction
        /// </summary>
        public override int GetHashCode()
        {
            return (Convert.ToInt32((Numerator ^ Denominator) & 0xFFFFFFFF));
        }

        /// <summary>
        /// internal function for negation
        /// </summary>
        private static Fraction Negate(Fraction frac1)
        {
            long iNumerator = -frac1.Numerator;
            long iDenominator = frac1.Denominator;
            return (new Fraction(iNumerator, iDenominator));

        }

        /// <summary>
        /// internal functions for binary operations
        /// </summary>
        private static Fraction Add(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    long iNumerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return (new Fraction(iNumerator, iDenominator));
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Overflow occurred while performing arithemetic operation");
            }
            catch (Exception)
            {
                throw new FractionException("An error occurred while performing arithemetic operation");
            }
        }

        private static Fraction Multiply(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    long iNumerator = frac1.Numerator * frac2.Numerator;
                    long iDenominator = frac1.Denominator * frac2.Denominator;
                    return (new Fraction(iNumerator, iDenominator));
                }
            }
            catch (OverflowException)
            {
                throw new FractionException("Overflow occurred while performing arithemetic operation");
            }
            catch (Exception)
            {
                throw new FractionException("An error occurred while performing arithemetic operation");
            }
        }

        /// <summary>
        /// The function returns GCD of two numbers (used for reducing a Fraction)
        /// </summary>
        private static long GCD(long iNo1, long iNo2)
        {
            // take absolute values
            if (iNo1 < 0) iNo1 = -iNo1;
            if (iNo2 < 0) iNo2 = -iNo2;

            do
            {
                if (iNo1 < iNo2)
                {
                    long tmp = iNo1;  // swap the two operands
                    iNo1 = iNo2;
                    iNo2 = tmp;
                }
                iNo1 = iNo1 % iNo2;
            } while (iNo1 != 0);
            return iNo2;
        }

        /// <summary>
        /// The function reduces(simplifies) a Fraction object by dividing both its numerator 
        /// and denominator by their GCD
        /// </summary>
        public static void ReduceFraction(Fraction frac)
        {
            try
            {
                if (frac.Numerator == 0)
                {
                    frac.Denominator = 1;
                    return;
                }

                long iGCD = GCD(frac.Numerator, frac.Denominator);
                frac.Numerator /= iGCD;
                frac.Denominator /= iGCD;

                if (frac.Denominator < 0)   // if -ve sign in denominator
                {
                    //pass -ve sign to numerator
                    frac.Numerator *= -1;
                    frac.Denominator *= -1;
                }
            } // end try
            catch (Exception exp)
            {
                throw new FractionException("Cannot reduce Fraction: " + exp.Message);
            }
        }

    }   //end class Fraction


    /// <summary>
    /// Exception class for Fraction, derived from System.Exception
    /// </summary>
    public class FractionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.FractionException"/> class.
        /// </summary>
		public FractionException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.FractionException"/> class.
        /// </summary>
        /// <param name="Message">Message.</param>
        public FractionException(string Message) : base(Message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Utilities.FractionException"/> class.
        /// </summary>
        /// <param name="Message">Message.</param>
        /// <param name="InnerException">Inner exception.</param>
        public FractionException(string Message, Exception InnerException) : base(Message, InnerException)
        { }
    }   //end class FractionException


}