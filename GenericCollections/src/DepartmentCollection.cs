using System.Collections.Generic;

namespace GenericCollections
{
    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {   
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);
            return this;
        }     
    }
}