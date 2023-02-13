namespace firstMVCAPP.Models
{
    public class Employee
    {
        public int eId { get; set; }
        public string eName { get; set; } = "";
        public double eSalary { get; set; }
        public bool eIsPermenant { get; set; }
        public string eDesignation { get; set; } = "";

        static List<Employee> eList = new List<Employee>()
        {
            new Employee(){ eId=101, eName="Nikhil", eDesignation="Consultant", eIsPermenant=true, eSalary=10000 },
            new Employee(){ eId=102, eName="Akshay", eDesignation="Trainer", eIsPermenant=false, eSalary=50000 },
            new Employee(){ eId=103, eName="Priya", eDesignation="Sales", eIsPermenant=true, eSalary=10000 },
            new Employee(){ eId=104, eName="Riya", eDesignation="HR", eIsPermenant=true, eSalary=10000 },
            new Employee(){ eId=105, eName="Jiya", eDesignation="Consultant", eIsPermenant=true, eSalary=80000 },
            new Employee(){ eId=106, eName="Diya", eDesignation="Consultant", eIsPermenant=false, eSalary=10000 },
            new Employee(){ eId=107, eName="Mohan", eDesignation="Consultant", eIsPermenant=true, eSalary=12000 }
        };

        public List<Employee> GetAllEmployees()
        {
            return eList;
        }

    }
}
