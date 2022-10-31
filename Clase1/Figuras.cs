namespace BP.NetCore
{
    interface IFiguras
    {
        double Dibujar();
    }
    public class Cuadrado : IFiguras
    {
        protected int lado;
        public Cuadrado(int l)
        {
            lado = l;
        }
        public double Dibujar()
        {
            int area;
            area = lado * lado;
            return area;
        }
    }
    public class Circulo : IFiguras
    {
        protected double radio;
        public Circulo(double r)
        {
            radio = r;
        }
        public double Dibujar()
        {
            double area;
            area = System.Math.PI * radio;
            return area;
        }
    }
    public class Triangulo : IFiguras
    {
        protected double baseT;
        protected double altura;
        public Triangulo(double b, double a)
        {
            baseT = b;
            altura = a;
        }
        public double Dibujar()
        {
            double area;
            area = (baseT * altura) / 2;
            return area;
        }
    }

}