using HRMS.Application.ISecurityService;
using HRMScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Infrastructure.SecurityServices
{
    public class Encryption : IEncryption
    {
        public void EncryptPasswordAsync(Employee employee, string password)
        {
            using(var hmc=new HMACSHA512())
            {
                byte[] passwordSalt = hmc.Key;
                byte[] passwordHash=hmc.ComputeHash(Encoding.ASCII.GetBytes(password));
                
                employee.PasswordHash=passwordHash;
                employee.PasswordSalt = passwordSalt;

            }
        }

        public string GetRandomPassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new();
            Random rnd = new();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public bool VerifyPasswordAsync(string password, byte[] PasswordHash, byte[] PasswordSalt)
        {
            using(var hmc= new HMACSHA512(PasswordSalt))
            {
                byte[] computed = hmc.ComputeHash(Encoding.ASCII.GetBytes(password));
                return computed.SequenceEqual(PasswordHash);
            }
        }
    }
}
