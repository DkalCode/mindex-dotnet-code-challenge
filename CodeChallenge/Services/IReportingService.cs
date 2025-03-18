using CodeChallenge.Models;
using System;

namespace CodeChallenge.Services
{
    public interface IReportingService
    {
        ReportingStructure GetById(string id);
    }
}
