using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AdminTransaction at = new AdminTransaction();
                Console.WriteLine("Kuber Bank");
                char ch;
                do
                {
                    Console.WriteLine("---------Login---------");
                    Console.WriteLine("Enter User Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Pasword");
                    string pass = Console.ReadLine();
                    //Console.Clear();
                    int c = at.Check(name, pass);
                    if (c == 1)
                    {

                        char l;
                        Console.WriteLine("-------Admin Login--------");
                        do
                        {

                            Console.WriteLine("1. Add User\n2. Update User \n3. Delete User\n4. Activate User\n5. Deactivate User\n6. Exit\n7. Display");
                            int opt = Convert.ToInt32(Console.ReadLine());
                            switch (opt)
                            {
                                case 1:
                                    at.AddUser();
                                    break;
                                case 2:
                                    at.UpdateUser();
                                    break;
                                case 3:
                                    at.DeleteUser();
                                    break;
                                case 4:
                                    at.Activate();
                                    break;
                                case 5:
                                    at.Deactivate();
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    at.Display();
                                    break;
                            }
                            Console.WriteLine("Press 'y' for continue else 'n' for logout...!!!!");
                            l = Convert.ToChar(Console.ReadLine());
                            Console.Clear();

                        } while (l == 'Y' || l == 'y');
                    }
                    else if (c > 0)
                    {
                        char l1;
                        Payee p = new Payee();
                        Console.WriteLine("----------User Login------");
                        do
                        {
                            Console.WriteLine("1. Balance Enquiry\n2. Add Payee\n3. Remove Payee\n4. Transfer Money\n5. Cash Deposit\n6. Withdraw Money\n7. Exit");
                            int opt = Convert.ToInt32(Console.ReadLine());
                            switch (opt)
                            {
                                case 1:
                                    at.BalanceEnquiry(c);
                                    break;
                                case 2:
                                    p.UserId = (c);
                                    Console.WriteLine("Enter Payee Id");
                                    p.PayeeId = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Enter Payee Name");
                                    p.PayeeName = Console.ReadLine();
                                    Console.WriteLine("Enter Account Number");
                                    p.AccountNo = Convert.ToInt32(Console.ReadLine());
                                    at.AddPayee(p);
                                    break;
                                case 3:
                                    Console.WriteLine("Enter Payee Id To Remove");
                                    int id1 = Convert.ToInt32(Console.ReadLine());
                                    at.RemovePayee((c), id1);
                                    break;
                                case 4:
                                    at.MoneyTransfer(c);
                                    break;
                                case 5:
                                    at.AddBalance(c);
                                    break;
                                case 6:
                                    at.Withdraw(c);
                                    break;
                                case 7:
                                    break;
                            }
                            Console.WriteLine("Press 'y' for continue else 'n' for logout...!!!!");
                            l1 = Convert.ToChar(Console.ReadLine());
                            Console.Clear();
                        } while (l1 == 'Y' || l1 == 'y');
                    }
                    else if (c == 0)
                    {
                        Console.WriteLine("Account is Deactive Please Contact to Bank Admin");
                    }
                    else if (c == -1)
                    {
                        Console.WriteLine("Please enter valid User name and Password....!!!!");
                    }
                    Console.WriteLine("Do you want to login again then press 'y' else 'n'");
                    ch = Convert.ToChar(Console.ReadLine());
                    Console.Clear();
                } while (ch == 'y' || ch == 'Y');
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
