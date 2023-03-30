namespace PTLabTask0
{
    public class Calculator
    {
        public int Add( int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        public int Multiply(int a, int b) 
        {  
            return a * b; 
        }
        public double Divide(int a, double b) 
        {
            if(b == 0)
            {
                throw new ArithmeticException("Division by 0 is not allowed.");
            }
            return a / b; 
        }
    }
}
