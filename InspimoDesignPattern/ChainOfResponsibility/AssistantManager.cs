using InspimoDesignPattern.DAL;
using InspimoDesignPattern.Models;

namespace InspimoDesignPattern.ChainOfResponsibility
{
    public class AssistantManager : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if (req.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Merve Yıldız";
                customerProcess.EmployeeNameDescription = "Müşterinin talep ettiği tutar müşteriye aktarıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Merve Yıldız";
                customerProcess.EmployeeNameDescription = "Müşterinin talep ettiği tutar veznedar tarafından ödenemedi, işlem Şube Müdürüne yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }

        }
    }
}
