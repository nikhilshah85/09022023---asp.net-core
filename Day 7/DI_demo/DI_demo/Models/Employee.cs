namespace DI_demo.Models
{
    public class Employee
    {
        public int eId { get; set; }
        public string eName { get; set; }
        public string eDesigtnation { get; set; }
        public double eSalary { get; set; }
        public bool eIsPermenant { get; set; }

        static List<Employee> eLIst = new List<Employee>()
        {
            new Employee(){ eId=101, eName="Karan", eDesigtnation="Sales", eIsPermenant=true, eSalary=4000},
            new Employee(){ eId=102, eName="Rohan", eDesigtnation="HR", eIsPermenant=true, eSalary=14000},
            new Employee(){ eId=103, eName="Mohan", eDesigtnation="Sales", eIsPermenant=true, eSalary=24000},
            new Employee(){ eId=104, eName="Sohan", eDesigtnation="Sales", eIsPermenant=false, eSalary=34000},
            new Employee(){ eId=105, eName="Priya", eDesigtnation="HR", eIsPermenant=true, eSalary=44000},
            new Employee(){ eId=106, eName="Riya", eDesigtnation="Sales", eIsPermenant=false, eSalary=7000},
        };

        public List<Employee> GetAllEmployees()
        {
            return eLIst;
        }

        public Employee GetEmpById(int id)
        {
            var emp = eLIst.Find(e => e.eId == id);
            if (emp !=null)
            {
                return emp;
            }
            throw new Exception("Employee Not Found");
        }
    }
}
