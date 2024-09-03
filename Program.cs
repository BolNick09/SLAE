namespace Indexators
{
    public class Laptop
    {
        public string vendor { get; set; }
        public double price { get; set; }
        public override string ToString()
        {
            return $"{vendor} {price}";
        }
    }
    enum Vendors
    {
        Asus = 0,
        Huawei = 1,
        Mac = 2,
        Acer = 3,
        Ahahahaha = 4
    }
    public class Shop
    {
        Laptop[] laptopArr;
        public Shop(int size)
        {
            laptopArr = new Laptop[size];
        }
        public int length
        {
            get { return laptopArr.Length; }
        }

        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptopArr.Length)
                    return laptopArr[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                laptopArr[index] = value;
            }
        }
        public Laptop this[string name]
        {
            get
            {
                if (Enum.IsDefined(typeof(Vendors), name))
                {
                    for (int i = 0; i <laptopArr.Length; i++)
                    {
                        if (laptopArr[i].vendor == name)
                            return laptopArr[i];
                    }
                    throw new Exception("Не найден");
                }
                else
                    return new Laptop();
            }
            set
            {
                if (Enum.IsDefined(typeof(Vendors), name))
                    laptopArr[(int)Enum.Parse(typeof(Vendors), name)] = value;
            }
        }

        public int findByPrice(double price)
        {
            for (int i = 0; i < laptopArr.Length; i++)
            {
                if (laptopArr[i].price == price)
                    return i;
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get
            {
                if (findByPrice(price) >= 0)
                    return this[this.findByPrice(price)];
                throw new Exception("Недопустимая стоимость");
            }
            set
            {
                if (findByPrice(price) >= 0)
                    this[this.findByPrice(price)] = value;
            }

        }
    }
    internal class Program
    {   
        
        static void Main(string[] args)
        {
            //Код на занятии
            /*
            Shop lapShop = new Shop(4);
            lapShop[0] = new Laptop { vendor = "Huawei", price = 30000 };
            lapShop[1] = new Laptop { vendor = "Asus", price = 40000 };
            lapShop[2] = new Laptop { vendor = "Acer", price = 50000 };
            lapShop[3] = new Laptop { vendor = "Ahahahaha", price = 50000 };


            try
            {
                for (int i = 0; i < lapShop.length; i++)
                    Console.WriteLine(lapShop[i]);
                //foreach (var i in lapShop)
                //    Console.WriteLine(i);

                Console.WriteLine();

                Console.WriteLine($"Asus: {lapShop["Asus"]}");
                Console.WriteLine($"HP: {lapShop["HP"]}");

                lapShop["HP"] = new Laptop();//игнор

                Console.WriteLine($"Price: {lapShop[50000.0]}");
                Console.WriteLine($"Price: {lapShop[150000.0]}");

                lapShop[150000.0] = new Laptop();//игнор
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
            */
            //ДЗ, решение СЛАУ
            
     
            Console.WriteLine("Введите первое уравнение (A1, B1, разделенные запятой): ");
            string equation1 = Console.ReadLine();

            Console.WriteLine("Введите второе уравнение (A2, B2, разделенные запятой): ");
            string equation2 = Console.ReadLine();

            LinearEquation eq1 = LinearEquation.Parse(equation1);
            LinearEquation eq2 = LinearEquation.Parse(equation2);

            double x = 1 / (eq2.getA() - eq2.getB() * eq1.getA() / eq1.getB());
            double y = -eq1.getA() * x / eq1.getB();




            Console.WriteLine($"X = {x}");
            Console.WriteLine($"Y = {y}");
            
        }
    }
}
