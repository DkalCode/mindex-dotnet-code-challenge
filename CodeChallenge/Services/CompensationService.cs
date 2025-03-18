using System;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        /* 
         * Purpose: Handles logic for the creation of a new compensation.
         * Paramaters: Compensation
         * Returns: Compensation
         */
        public Compensation Create(Compensation compensation)
        {
            // Input Validation
            if (compensation != null)
            {
                Compensation res = _compensationRepository.Add(compensation);
                if (res == null) return null;
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        /* 
         * Purpose: Handles logic for the retrieval of a compensation by employeeId.
         * Paramaters: Compensation
         * Returns: Compensation
         */
        public Compensation GetById(string id)
        {
            // Input Validation
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetById(id);
            }

            return null;
        }
    }
}
