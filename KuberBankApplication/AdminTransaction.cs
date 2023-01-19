using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplication
{
    class AdminTransaction
    {
        public  static int count=1 ;
        public  static int accountno = 1201;
        public List<User> userlist = new List<User>
        {
            new User{UserId=count,UserName="Dinesh",UserPassword="Admin123",UserRole=UserRole.Admin,IsActive=IsActive.Active}
        };
        public List<UserAccount> acclist = new List<UserAccount>
        {
            new UserAccount{UserId=count,Name="Dinesh",AccountNo=accountno,Balance=5000}
        };
        public List<Payee> payeelist = new List<Payee>();

        public void AddUser()
        {
            User u = new User();
            UserAccount ua = new UserAccount();
            accountno++;
            count++;
            u.UserId = count;
            u.UserRole = UserRole.Customer;
            u.IsActive = IsActive.Active;
            Console.WriteLine("Eenter User Name");
            u.UserName = Console.ReadLine();
            ua.UserId = u.UserId;
            ua.Name = u.UserName;
            ua.AccountNo = accountno;
            ua.Balance = 5000;
            Console.WriteLine("Enter Password");
            u.UserPassword = Console.ReadLine();
            userlist.Add(u);
            acclist.Add(ua);
            Console.WriteLine("User added Successfully......!!!!!");

        }
        public void UpdateUser()
        {
            try
            {
                User u = new User();
                Console.WriteLine("Enter user id for Update");
                u.UserId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Eenter User Name to Update");
                u.UserName = Console.ReadLine();
                Console.WriteLine("Enter Password to UPdate");
                u.UserPassword = Console.ReadLine();
                Console.WriteLine("Enter User Role to Update");
                Console.WriteLine("1. Admin\n2. Customer");
                int ur = Convert.ToInt32(Console.ReadLine());
                if (ur == 1)
                {
                    u.UserRole = UserRole.Admin;
                }
                else if (ur == 2)
                {
                    u.UserRole = UserRole.Customer;
                }
                foreach (User item in userlist)
                {
                    if (item.UserId == u.UserId)
                    {
                        item.UserName = u.UserName;
                        item.UserPassword = u.UserPassword;
                        item.UserRole = u.UserRole;
                        Console.WriteLine("User Updated Successfully.....!!!");
                        break;
                    }
                }
                foreach (UserAccount item in acclist)
                {
                    if (item.UserId == u.UserId)
                    {
                        item.Name = u.UserName;
                        break;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteUser()
        {
            try
            {
                Console.WriteLine("Enter Id to Delete");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (User item in userlist)
                {
                    if (item.UserId == id)
                    {
                        userlist.Remove(item);
                        Console.WriteLine("User Details Deleted...!!!");
                        break;
                    }
                }
                foreach (UserAccount item in acclist)
                {
                    if (item.UserId == id)
                    {
                        acclist.Remove(item);
                        Console.WriteLine("User Account Deleted...!!!");
                        break;
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void Activate()
        {
            Console.WriteLine("Enter User Id for activate the account");
            int id = Convert.ToInt32(Console.ReadLine());
            int c = Check(id);
            if (c == 1)
            {
                foreach (User item in userlist)
                {
                    if (item.UserId == id)
                    {
                        item.IsActive = IsActive.Active;
                        Console.WriteLine("User Account Activated...!!!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter Wrong UserName.....!!!!");
            }
        }
        public int Check(int id)
        {
            foreach (User item in userlist)
            {
                if (item.UserId == id)
                {
                    return 1;
                }
            }
            return 0;
        }

        public void Deactivate()
        {
            //CheckMethods check = new CheckMethods();
            Console.WriteLine("Enter User Id for deactivate account");
            int id = Convert.ToInt32(Console.ReadLine());
            int c = Check(id);
            if (c == 1)
            {
                foreach (User item in userlist)
                {
                    if (item.UserId == id)
                    {
                        item.IsActive = IsActive.Deactive;
                        Console.WriteLine("User Account Deactivated....!!!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter Wrong UserName.....!!!!");
            }
        }
        public int Check(string name, string pass)
        {

            foreach (User item in userlist)
            {
                if (item.UserName == name && item.UserPassword == pass && item.UserRole == UserRole.Admin)
                {

                    return 1;

                }
                else if (item.UserName == name && item.UserPassword == pass && item.UserRole == UserRole.Customer)
                {
                    if (item.IsActive == IsActive.Active)
                    {
                        return (item.UserId);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return -1;

        }
        public List<User> GetList()
        {
            return userlist;
        }
        public void Display()
        {
            Console.WriteLine("------------User List------------");
            foreach (User t in userlist)
            {
                Console.WriteLine($"{t.UserId}  {t.UserName}  {t.UserPassword} {t.UserRole}  {t.IsActive}");
            }
            Console.WriteLine("----------------Account List--------------");
            foreach (UserAccount item in acclist)
            {
                Console.WriteLine($"{item.UserId}  {item.Name}  {item.AccountNo}  {item.Balance}");
            }
        }
        public void BalanceEnquiry(int id)
        {
            foreach (UserAccount item in acclist)
            {
                if (item.UserId == id)
                {
                    Console.WriteLine("Balance = " + item.Balance);
                    break;
                }
            }
        }
        public void AddPayee(Payee p)
        {
            payeelist.Add(p);
            Console.WriteLine("Payee Add Succesfull...!!!!");
        }
        public void RemovePayee(int id,int id1)
        {
            foreach (Payee item in payeelist)
            {
                if (item.UserId == id && item.PayeeId == id1)
                {
                    payeelist.Remove(item);
                    Console.WriteLine("Payee Remove Succesfully...!!!!");
                    break;
                }
            }
        }
        public void MoneyTransfer(int id)
        {
            foreach (Payee item in payeelist)
            {
                if (item.UserId == id)
                {
                    Console.WriteLine($"{item.PayeeId}   {item.PayeeName}   {item.AccountNo}");
                }
            }
            Console.WriteLine("Select Payee Id to Transfer Amount");
            int id1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter amount to transfer");
            double amount = Convert.ToDouble(Console.ReadLine());
            int accountno = 1;
            
            foreach (Payee item in payeelist)
            {
                if(item.UserId==id && item.PayeeId == id1)
                {
                    accountno = item.AccountNo;
                    
                    break;
                }
            }
            foreach (UserAccount item in acclist)
            {
                if (item.AccountNo == accountno)
                {
                    item.Balance = item.Balance + amount;
                    Console.WriteLine("Money Transfer Successfully...!!!!");
                }else if (item.UserId == id)
                {
                    item.Balance = item.Balance - amount;
                }
            }
        }
        public void AddBalance(int id)
        {
            Console.WriteLine("Enter amount to Deposit");
            double amount = Convert.ToDouble(Console.ReadLine());
            foreach (UserAccount item in acclist)
            {
                if (item.UserId == id)
                {
                    item.Balance = item.Balance + amount;
                    Console.WriteLine("Amount added to your account");
                    break;
                }
            }
        }
        public void Withdraw(int id)
        {
            Console.WriteLine("Enter amount to Withdraw");
            double amount = Convert.ToDouble(Console.ReadLine());
            foreach (UserAccount item in acclist)
            {
                if (item.UserId == id)
                {
                    item.Balance = item.Balance - amount;
                    Console.WriteLine("Amount  Deducted");
                    break;
                }
            }
        }
    }
}
