using CodeChallenge.Models;
using System;
using System.Collections.Generic;

namespace CodeChallenge.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IEmployeeService _employeeService;

        public ReportingService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /* 
         * Purpose: Allows for the retrieval of the total reporting count for a given employee.
         * Paramaters: string
         * Returns: ReportingStructure
         */
        public ReportingStructure GetById(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                var employee = _employeeService.GetById(id);

                // Seperated the logic below to be able to use the function recursively.
                int totalReporting = CalculateReporting(employee.DirectReports);

                return new ReportingStructure
                {
                    Employee = employee,
                    NumberOfReports = totalReporting
                };
            }

            return null;
        }

        /* 
         * Purpose: Recursively calculates the total reports from a source employee. 
         * Paramaters: List<Employee>
         * Returns: int
         */
        private int CalculateReporting(List<Employee> directReports)
        {
            // Check if the provided list is null or empty.
            if (directReports == null || directReports.Count == 0) return 0;

            int total = 0;

            foreach (var report in directReports)
            {
                // Increment the total for the current employee's directReports.
                total++;

                // Get the next level of direct reports and add to the total recursively.
                List<Employee> next = _employeeService.GetById(report.EmployeeId).DirectReports;
                total += CalculateReporting(next);
            }

            return total;
        }

    }
}
