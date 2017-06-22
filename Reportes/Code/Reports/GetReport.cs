using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Reportes
{
    public class GetReport
    {
        private Report myReport;

        public GetReport(Report report)
        {
            this.myReport = report;
        }

        public DataTable GetData(DateTime inicio, DateTime final)
        {
            return myReport.ImplementReport(inicio, final);
        }

        public String GenerateFile(DataTable data)
        {
            return myReport.CreateFile(data);
        }
    }
}