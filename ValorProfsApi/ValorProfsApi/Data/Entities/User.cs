using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ValorProfsApi.Data.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }
                
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}
