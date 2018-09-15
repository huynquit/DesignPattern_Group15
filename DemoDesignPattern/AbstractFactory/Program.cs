using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{


    public interface Student  //Abstract Product
    {
        void Info();
    }

    public class CNPM : Student    //Product
    {
        public void Info()
        {
            Console.WriteLine("Sinh vien khoa CNPM");
        }
    }
    public class HTTT : Student    //Product
    {
        public void Info()
        {
            Console.WriteLine("Sinh vien khoa HTTT");
        }
    }

    public interface Employee  //Abstract Product
    {
        void Work();
    }

    public class DuLich : Employee     //Product
    {
        public void Work()
        {
            Console.WriteLine("Nhan vien cong ty Du lich");
        }
    }

    public class BaoChi : Employee    //Product
    {
        public void Work()
        {
            Console.WriteLine("Nhan vien cong ty bao chi");
        }
    }

    public abstract class PeopleFactory      //Abstract Factory
    {
        public abstract Student getStudent(string student);
        public abstract Employee getEmployee(string employee);
    }

    public class StudentFactory : PeopleFactory    //Concrete Factory
    {
        public override Student getStudent(string _uit)
        {   
            switch(_uit)
            {
                case "CNPM":
                    return new CNPM();
                case "HTTT":
                    return new HTTT();
                default:
                    return null; 
            }
        }

        public override Employee getEmployee(string _ussh)
        {
            return null;
        }
    }

    public class EmployeeFactory : PeopleFactory   //Concrete Factory
    {
        public override Student getStudent(string _uit)
        {
            return null;
        }

        public override Employee getEmployee(string _ussh)
        {
            switch (_ussh)
            {
                case "DuLich":
                    return new DuLich();
                case "BaoChi":
                    return new BaoChi();
                default:
                    return null;
            }
        }

    }

    public class FactoryProducer
    {
        public static PeopleFactory getFactory(String choice)
        {

            if (choice.Equals("STUDENT"))
            {
                return new StudentFactory();

            }
            else if (choice.Equals("EMPLOYEE"))
            {
                return new EmployeeFactory();
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PeopleFactory studentFactory = FactoryProducer.getFactory("STUDENT");

            Student student1 = studentFactory.getStudent("CNPM");
            student1.Info();

            Student student2 = studentFactory.getStudent("HTTT");
            student2.Info();

            PeopleFactory employeeFactory = FactoryProducer.getFactory("EMPLOYEE");

            Employee employee1 = employeeFactory.getEmployee("DuLich");
            employee1.Work();

            Employee employee2 = employeeFactory.getEmployee("BaoChi");
            employee2.Work();

            Console.ReadKey();
        }
    }

}
