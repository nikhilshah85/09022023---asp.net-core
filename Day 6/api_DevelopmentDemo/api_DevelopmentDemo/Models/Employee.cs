namespace api_DevelopmentDemo.Models
{
    public class Employee
    {
        public int eNo { get; set; }
        public string eName { get; set; }
        public string eDesignation { get; set; }
        public double eSalary { get; set; }
        public bool eIsPermenant { get; set; }

        static List<Employee> eList = new List<Employee>()
        {
            new Employee(){ eNo = 101, eName="Sameer", eDesignation="Sales", eIsPermenant=true, eSalary=12000 },
            new Employee(){ eNo = 102, eName="Karan", eDesignation="Sales", eIsPermenant=true, eSalary=2000 },
            new Employee(){ eNo = 103, eName="Khushi", eDesignation="HR", eIsPermenant=false, eSalary=1000 },
            new Employee(){ eNo = 104, eName="Anjali", eDesignation="Sales", eIsPermenant=true, eSalary=5000 },
            new Employee(){ eNo = 105, eName="Priya", eDesignation="Accounts", eIsPermenant=true, eSalary=16000 },
            new Employee(){ eNo = 106, eName="Mohan", eDesignation="Sales", eIsPermenant=true, eSalary=15000 },
            new Employee(){ eNo = 107, eName="Rohan", eDesignation="Sales", eIsPermenant=true, eSalary=11000 },
            new Employee(){ eNo = 108, eName="Sohan", eDesignation="Accounts", eIsPermenant=false, eSalary=10000 },
        };


        public List<Employee> GetAllEmployee()
        {
            return eList;
        }

        public int TotalEmployees()
        {
            return eList.Count;
        }

        public List<Employee> GetEmployeesByStatus(bool ispermenant)
        {
            var permenantEmp = eList.FindAll(e => e.eIsPermenant == ispermenant);
            if (permenantEmp != null)
            {
                return permenantEmp;
            }
            throw new Exception("No Employees Found");
        }

        public Employee GetEmployeeByNo(int eno)
        {
            var emp = eList.Find(e => e.eNo == eno);
            if (emp != null)
            {
                return emp;
            }
            throw new Exception("Employee Not Found");
        }

        public double TotalSalaryPaid()
        {
            var total = eList.Sum(e => e.eSalary);
            return total;
        }
    }
}

















