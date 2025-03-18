using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Data;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace CodeChallenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {

        private readonly EmployeeContext _employeeContext;

        public CompensationRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        /* 
         * Purpose: Adds a new Compensation to the database.
         * Paramaters: Compensation
         * Returns: Compensation
         */
        public Compensation Add(Compensation compensation)
        {
            // Generating a new GUID for the compensation.
            compensation.CompensationId = Guid.NewGuid().ToString();
            
            /* Because the Employee object thats passed in from the body could be incomplete (ex: user only provides employeeId) we need
             * to take the employeeId provided and retrieve the full employee object from the context. This will allow the Compensation to contain
             * all of the required data.
            */

            Employee employee = _employeeContext.Employees.SingleOrDefault(e => e.EmployeeId == compensation.Employee.EmployeeId);

            if (employee == null) return null;

            compensation.Employee = employee;

            // Taking our newly modified compensation object and adding it to the context.
            _employeeContext.Compensations.Add(compensation);

            return compensation;
        }

        /* 
         * Purpose: Gets a Compensation based on the provided employeeId.
         * Paramaters: string
         * Returns: Compensation
         */
        public Compensation GetById(string id)
        {
            return _employeeContext.Compensations.Include(e => e.Employee).SingleOrDefault(e => e.Employee.EmployeeId == id);
        }

        /* 
         * Purpose: Asynchronously saves changes to the database.
         * Paramaters: N/A
         * Returns: Task
         */
        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
