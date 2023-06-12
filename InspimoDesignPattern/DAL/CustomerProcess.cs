namespace InspimoDesignPattern.DAL
{
    public class CustomerProcess
    {
        public int CustomerProcessID { get; set; }
        public string CustomerProcessName { get; set; }
        public decimal Amount { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNameDescription { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
