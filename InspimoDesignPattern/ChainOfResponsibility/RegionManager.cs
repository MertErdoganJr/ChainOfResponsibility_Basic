using InspimoDesignPattern.DAL;
using InspimoDesignPattern.Models;

namespace InspimoDesignPattern.ChainOfResponsibility
{
    public class RegionManager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Serkan Kaya";
                customerProcess.EmployeeNameDescription = "Müşterinin talep ettiği tutar müşteriye aktarıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Serkan Kaya";
                customerProcess.EmployeeNameDescription = "Müşterinin talep ettiği tutar Bölge Müdürü tarafından ödenemedi, işlem yapılamadı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
        }
    }
}
