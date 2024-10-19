using SuperMarket.Business.EnumClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business
{
    public class Employee
    {
        private string name { get; set; }
        private string age { get; set; }
        private string CPF { get; set; }
        private string neighborhood { get; set; }

        private static  List<RoleEnum> roleList;

        private static Stack _stack = new Stack();
        public Employee()
        {
        }

        public Employee(string employeeName, string employeeAge, string employeeCPF, string employeeNeighborhood)
        {
            this.name = employeeName;
            this.age = employeeAge;
            this.CPF = employeeCPF;
            this.neighborhood = employeeNeighborhood;
        }
      
        public bool isValidCPF(string CPF)
        {
            if(CPF.Length >= 11 || CPF.Length <= 11 )
             
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isRoleValid(RoleEnum role)
        {
            roleList = Enum.GetValues(typeof(RoleEnum))
               .Cast<RoleEnum>()
               .ToList();
            return roleList.Contains(role);
        }

        public void ShowDisponibleRoles()
        {
            var availableRoles = Enum.GetValues(typeof(RoleEnum)).Cast<RoleEnum>();
            foreach (var role in availableRoles)
            {
                Console.WriteLine($"Jobs Avaiable -> {role}");
            }
        }

       
        public void employeeRegister()
        {
            Console.WriteLine("Input the employee Name");
            string employeeName = Console.ReadLine();
            Console.WriteLine("Input the employee Age");
            int employeeAge = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the Neighborhood of the Employee");
            string employeeNeighborhood = Console.ReadLine();
            Console.WriteLine("Input the CPF Number");
            string employeeCPF = Console.ReadLine();
            Console.WriteLine("Set Employee Role");
            string Role = Console.ReadLine();
            Employee employee = new Employee(employeeName, employeeAge.ToString(), employeeCPF, employeeNeighborhood);
            if (isValidCPF(employeeCPF))
            {
                if (Enum.TryParse(Role, true, out RoleEnum role) && isRoleValid(role))
                {
                    Console.WriteLine($"The Employee  was registred successfully in the role {Role}");
                    _stack.Push(employee);
                }
                else
                {
                    Console.WriteLine("Error !");
                }
             
            }
        }
    }
}
