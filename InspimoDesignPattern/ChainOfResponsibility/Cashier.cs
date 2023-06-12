using InspimoDesignPattern.DAL;
using InspimoDesignPattern.Models;

namespace InspimoDesignPattern.ChainOfResponsibility
{
    public class Cashier : Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            var context = new Context();
            if(req.Amount<=100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.CustomerProcessName = req.CustomerProcessName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.EmployeeNameDescription = "Müşterinin talep ettiği tutar müşteriye aktarıldı";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if(NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount=req.Amount;
                customerProcess.CustomerProcessName=req.CustomerProcessName;
                customerProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                customerProcess.EmployeeName = "Ali Yıldız";
                customerProcess.EmployeeNameDescription = "Müşterinin talep ettiği tutar veznedar tarafından ödenemedi, işlem Şube Müdür Yardımcısına yönlendirildi";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
