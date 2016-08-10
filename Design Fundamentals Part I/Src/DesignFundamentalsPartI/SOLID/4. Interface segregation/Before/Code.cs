using System;
using System.Collections.Generic;

namespace SOLID._4._Interface_segregation.Before
{
    public interface IRepository
    {
        List<string> GetJurisdictions();
        List<string> GetJudges();
        List<string> GetIndustries();
        List<string> GetTopCases();
        List<string> GetDebtors(int projectId);
        object GetProjectInformation(int projectId);
        int GetProjectIdByCode(string projectCode);
        string GetDisclaimer(int projectId, string type);
        object GetHomePageHtml(int projectId);
    }

    class NewDataBaseRepository : IRepository
    {
        dynamic dbContext;
        public List<string> GetDebtors(int projectId)
        {
            throw new NotImplementedException();
        }

        public string GetDisclaimer(int projectId, string type)
            => dbContext.Case.GetDisclaimers(projectId, type);

        public object GetHomePageHtml(int projectId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetIndustries()
            => dbContext.Industry.GetAll();

        public List<string> GetJudges()
        {
            throw new NotImplementedException();
        }

        public List<string> GetJurisdictions()
            => dbContext.Juridistion.GetAll();

        public int GetProjectIdByCode(string projectCode)
        {
            throw new NotImplementedException();
        }

        public object GetProjectInformation(int projectId)
            => dbContext.Case.GetProjectInformation(projectId);

        public List<string> GetTopCases()
        {
            throw new NotImplementedException();
        }
    }

    class OldDataBaseRepository : IRepository
    {
        dynamic dbContext;

        public List<string> GetDebtors(int projectId)
            => dbContext.Debtor.ById(projectId);

        public string GetDisclaimer(int projectId, string type)
        {
            throw new NotImplementedException();
        }

        public object GetHomePageHtml(int projectId)
            => dbContext.Case.GetHomePage(projectId);

        public List<string> GetIndustries()
        {
            throw new NotImplementedException();
        }

        public List<string> GetJudges()
            => dbContext.Judges.GetAll();

        public List<string> GetJurisdictions()
        {
            throw new NotImplementedException();
        }

        public int GetProjectIdByCode(string projectCode)
            => dbContext.Case.GetByCode(projectCode);

        public object GetProjectInformation(int projectId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTopCases()
            => dbContext.Case.GetTopCases();
    }
}
