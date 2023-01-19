using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuberBankApplication
{
    public enum UserRole {Admin=1,Customer=2};
    public enum IsActive { Active=1,Deactive=2}
    class User
    {
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
        public IsActive IsActive { get; set; }
    }
    class UserAccount
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int AccountNo { get; set; }
        public double Balance { get; set; }
    }
    class Payee
    {
        public int UserId { get; set; }
        public int PayeeId { get; set; }
        public string PayeeName { get; set; }
        public int AccountNo { get; set; }
                                                
    }
}
