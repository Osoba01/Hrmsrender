using HRMScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Application.ISecurityService
{
    public interface IEncryption
    {
        void EncryptPasswordAsync(Employee employ, string password);
        bool VerifyPasswordAsync(string password, byte[] PasswordHash, byte[] PasswordSalt);

        string GetRandomPassword(int length);
    }
}
