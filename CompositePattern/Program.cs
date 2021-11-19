using System;
using System.Collections.Generic;

namespace CompositePattern
{
    class Program
    {
        interface IEmployee
        {
            string Name { get; set; }
            string Dept { get; set; }
            string Designation { get; set; }
            void DisplayDetails();
        }
        class Employee: IEmployee
        {

            public string Name { get; set; }
            public string Dept { get; set; }
            public string Designation { get; set; }
            public void DisplayDetails()
            {
                Console.WriteLine("\t lam viec tai phong {1}." + 
                    " Chi dinh : {2}", Name,Dept,Designation);
            }
        }
        class CompositeEmployee : IEmployee
        {
            public string Name { get; set; }
            public string Dept { get; set; }
            public string Designation { get; set; }
            private List<IEmployee> sublist = new List<IEmployee>();
            public void AddEmployee(IEmployee e )
            {
                sublist.Add(e);
            }
            public void RemoveEmployee(IEmployee e )
            {
                sublist.Remove(e);
            }
            public void DisplayDetails()
            {
                Console.WriteLine("\t lam viec tai phong {1}." +
                   " Chi dinh : {2}", Name, Dept, Designation);
                foreach (IEmployee e in sublist)
                {
                    e.DisplayDetails();
                }
            }
            

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Composite pattern***");
            Employee Toan1 = new Employee { Name = "Nguyen Van A", Dept = "Khoa Toan", Designation = "Giang Vien" };
            Employee Toan2 = new Employee { Name = "Nguyen Thi B", Dept = "Khoa Toan", Designation = "Giang Vien" };
            CompositeEmployee HODToan = new CompositeEmployee { Name = "Le Van C", Dept = "Khoa Toan", Designation = "Truong Khoa" };
            HODToan.AddEmployee(Toan1);
            HODToan.AddEmployee(Toan2);
            Employee CSEE1 = new Employee { Name = "Do Van H", Dept = "CSE", Designation = "Giang vien" };
            Employee CSEE2 = new Employee { Name = "Tran thi P ", Dept = "CSE", Designation = "Giang vien" };
            Employee CSEE3 = new Employee { Name = " Ly Phat T", Dept = "CSE", Designation = "Giang Vien" };

            CompositeEmployee HODCSE = new CompositeEmployee { Name = "Nguyen Van X", Dept = "CSE", Designation = "Truong Khoa" };
            HODCSE.AddEmployee(CSEE1);
            HODCSE.AddEmployee(CSEE2);
            HODCSE.AddEmployee(CSEE3);

            CompositeEmployee HTTruong = new CompositeEmployee { Name = "Dr. S", Dept = "Ke hoach QL", Designation = "Hieu Truong" };

            HTTruong.AddEmployee(HODToan);
            HTTruong.AddEmployee(HODCSE);

            Console.WriteLine("Thong tin tu hieu truong");
            HTTruong.DisplayDetails();

            Console.WriteLine("Thong tin tu khoa CSE");
            HODCSE.DisplayDetails();
            Console.WriteLine("---------------");
            Console.WriteLine("Thong tin cua GV toan 1");
            Toan1.DisplayDetails();

            Console.WriteLine("GV {0} nop don nghi khoa {1}",CSEE2.Name,CSEE2.Dept);
            HODCSE.RemoveEmployee(CSEE2);
            HODCSE.DisplayDetails();

            Console.ReadKey();
        }
    }
}
